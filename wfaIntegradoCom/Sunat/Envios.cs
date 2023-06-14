using CapaEntidad;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using selferviceSIGC.Model.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
//using System.ServiceModel;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using wfaIntegradoCom.Funciones;
using wfaIntegradoCom.ServicioFacturacion;
using Document = iTextSharp.text.Document;
using iTextSharp.text.pdf.qrcode;
using System.Drawing.Imaging;
using System.Drawing;
using ZXing;
using ZXing.Common;
using System.Text;
using QRCoder;
//using Xceed.Wpf.Toolkit;

namespace wfaIntegradoCom.Sunat
{
    public class Envios
    {
        string versionUbl="2.1";
        string versionEstruc="2.0";
        public string Ruta_Certificado { get; set; }
        public string Password_Certificado { get; set; }
        public string Rutaxml { get; set; }
        public string RutaEnvios { get; set; }
        public string RutaCDR { get; set; }

        public string[] GenerarFacturaBoletaXML(ParametrosFactura paramFactura,Cliente clsCliente,List<DetalleVenta> lstDetalleVentas)
        {

            //Cabecera del xml
            InvoiceType Factura = new InvoiceType();
            Factura.Cac = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2";
            Factura.Cbc = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2";
            Factura.Ccts = "urn:un:unece:uncefact:documentation:2";
            Factura.Ds = "http://www.w3.org/2000/09/xmldsig#";
            Factura.Ext = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2";
            Factura.Qdt = "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2";
            Factura.Udt = "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2";
            UBLExtensionType[] ublextensiones = new UBLExtensionType[11];
            UBLExtensionType ublExtension = new UBLExtensionType();
            ublextensiones[0] = ublExtension;
            Factura.UBLExtensions = ublextensiones;

            //Otorgamos la version UBL y la version del esquema del documento
            Factura.UBLVersionID = new UBLVersionIDType();
            Factura.UBLVersionID.Value = versionUbl;
            Factura.CustomizationID = new CustomizationIDType();
            Factura.CustomizationID.Value = versionEstruc;

            //Ingresar serie y numero de comprobante
            Factura.ID = new IDType();
            Factura.ID.Value = paramFactura.Serie + "-" + paramFactura.Correlativo;
            //Fecha de emision
            Factura.IssueDate = new IssueDateType();
            string fechaemision = Convert.ToDateTime(paramFactura.fecha_venta).ToString("yyyy-MM-dd");
            Factura.IssueDate.Value = Convert.ToDateTime(fechaemision);
            Factura.IssueTime = new IssueTimeType();
            string hora = Convert.ToDateTime(paramFactura.fecha_venta).ToString("HH:mm:ss");
            Factura.IssueTime.Value = Convert.ToDateTime(hora);

            //Fecha de vencimiento
            //Factura.DueDate = new DueDateType();
            //string fechavencimiento = Convert.ToDateTime(paramFactura.Fecha_de_pago).ToString("yyyy-MM-dd");
            //Factura.DueDate.Value = Convert.ToDateTime(fechavencimiento);

            //Tipo de factura
            InvoiceTypeCodeType TipoFactura = new InvoiceTypeCodeType();
            TipoFactura.listID = "0101";//Factura  de venta interna
            TipoFactura.listAgencyName = "PE:SUNAT";
            TipoFactura.listName = "Tipo de Documento";
            TipoFactura.name = "Tipo de Operacion";
            TipoFactura.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01";
            TipoFactura.listSchemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo51";
            TipoFactura.Value = paramFactura.CodigoComprobante;// == "01" && paramFactura.FormaDePagoFactura == "CRED" ? "02" : paramFactura.CodigoComprobante;
            Factura.InvoiceTypeCode = TipoFactura;

            //Leyenda del comprobante
            NoteType Leyenda = new NoteType();
            Leyenda.languageLocaleID = "1000";
            Leyenda.Value = paramFactura.PrecioALetras;
            List<NoteType> notas = new List<NoteType>();
            notas.Add(Leyenda);
            Factura.Note = notas.ToArray();

            //Tipo de moneda
            DocumentCurrencyCodeType moneda = new DocumentCurrencyCodeType();
            moneda.listID = "ISO 4217 Alpha";
            moneda.listName = "Currency";
            moneda.listAgencyName = "United Nations Economic Commission for Europe";
            moneda.Value = "PEN";
            Factura.DocumentCurrencyCode = moneda;

            //Cantidad de productos en el detalle de venta
            LineCountNumericType numeroProductos = new LineCountNumericType();
            numeroProductos.Value = paramFactura.contadorProductos;


            //Ingresar datos de la empresa emisora
            SignatureType Firma = new SignatureType();
            SignatureType[] Firmas = new SignatureType[2];
            PartyType partySign = new PartyType();
            ////Agregar el ruc Empresa emisora
            PartyIdentificationType partyIdentificacion = new PartyIdentificationType();
            PartyIdentificationType[] partyIdentificacions = new PartyIdentificationType[2];
            IDType idFirma = new IDType();
            idFirma.Value = paramFactura.Serie + "-" + paramFactura.Correlativo;//Variables.claseEmpresa.Ruc;
            Firma.ID = idFirma;
            partyIdentificacion.ID = idFirma;
            partyIdentificacions[0] = partyIdentificacion;
            partySign.PartyIdentification = partyIdentificacions;
            Firma.SignatoryParty = partySign;
            ////Agregar notas
            NoteType Nota = new NoteType();
            NoteType[] Notas = new NoteType[2];
            Nota.Value = "Elaborado por HUSAT GPS";
            Notas[0] = Nota;
            Firma.Note = Notas;

            ////Ingresar la razon social de la empresa emisora
            PartyNameType partyName = new PartyNameType();
            PartyNameType[] partyNames = new PartyNameType[2];
            NameType1 RazonSocialFirma = new NameType1();
            RazonSocialFirma.Value = Variables.claseEmpresa.RazonSocial;
            partyName.Name = RazonSocialFirma;
            partyNames[0] = partyName;
            partySign.PartyName = partyNames;

            AttachmentType attachType = new AttachmentType();
            ExternalReferenceType externaReferencia = new ExternalReferenceType();
            URIType uri = new URIType();
            uri.Value = Variables.claseEmpresa.Ruc;
            externaReferencia.URI = uri;
            Firma.DigitalSignatureAttachment = attachType;

            attachType.ExternalReference = externaReferencia;
            Firma.DigitalSignatureAttachment = attachType;

            Firmas[0] = Firma;
            Factura.Signature = Firmas;
            //Codigo del documento de identidad de la empresa emisora
            SupplierPartyType empresa = new SupplierPartyType();
            PartyType party = new PartyType();
            PartyIdentificationType partyidentificacionN = new PartyIdentificationType();
            PartyIdentificationType[] partyidentificacionsN = new PartyIdentificationType[2];
            IDType idEmpresa = new IDType();
            idEmpresa.schemeID = "6";
            idEmpresa.schemeName = "Documento de Identidad";
            idEmpresa.schemeAgencyName = "PE:SUNAT";
            idEmpresa.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
            idEmpresa.Value = Variables.claseEmpresa.Ruc;
            partyidentificacionN.ID = idEmpresa;
            partyidentificacionsN[0] = partyidentificacionN;
            party.PartyIdentification = partyidentificacionsN;

            ////Razon social empresa
            PartyNameType partyname = new PartyNameType();
            List<PartyNameType> partynames = new List<PartyNameType>();
            NameType1 nameEmisor = new NameType1();
            nameEmisor.Value = Variables.claseEmpresa.RazonSocial;
            partyname.Name = nameEmisor;
            partynames.Add(partyname);
            party.PartyName = partynames.ToArray();

            //Establecimientos anexos y direccion de empresa emisora
            List<PartyLegalEntityType> partelegals = new List<PartyLegalEntityType>();
            PartyLegalEntityType partelegal = new PartyLegalEntityType();
            RegistrationNameType registronombre = new RegistrationNameType();
            registronombre.Value = Variables.claseEmpresa.RazonSocial;
            partelegal.RegistrationName = registronombre;
            ////Direccion de la empresa emisora
            AddressType direccionPL = new AddressType();
            IDType iddireccionPL = new IDType();
            iddireccionPL.schemeAgencyName = "PE:INEI";
            iddireccionPL.schemeName = "Ubigeos";
            iddireccionPL.Value = Variables.claseEmpresa.CodDepartamento + Variables.claseEmpresa.CodProvincia + Variables.claseEmpresa.CodDistrito;
            direccionPL.ID = iddireccionPL;
            AddressTypeCodeType anexo = new AddressTypeCodeType();
            anexo.listAgencyName = "PE:SUNAT";
            anexo.listName = "Establecimientos anexos";
            anexo.Value = "0000";
            direccionPL.AddressTypeCode = anexo;
            ////Indicar direccion fiscal de la empresa emisora
            CityNameType Departamento = new CityNameType();
            Departamento.Value = Variables.claseEmpresa.NomDepartamento;
            direccionPL.CityName = Departamento;
            CountrySubentityType provincia = new CountrySubentityType();
            provincia.Value = Variables.claseEmpresa.NomProvincia;
            direccionPL.CountrySubentity = provincia;
            DistrictType distrito = new DistrictType();
            distrito.Value = Variables.claseEmpresa.NomDistrito;
            direccionPL.District = distrito;

            List<AddressLineType> direcciones = new List<AddressLineType>();
            AddressLineType direccionEmisor = new AddressLineType();
            LineType datalocal = new LineType();
            datalocal.Value = Variables.claseEmpresa.Direccion;
            direccionPL.AddressLine = direcciones.ToArray();
            direccionEmisor.Line = datalocal;
            direcciones.Add(direccionEmisor);
            direccionPL.AddressLine = direcciones.ToArray();
            ////Pais empresa emisora
            CountryType pais = new CountryType();
            IdentificationCodeType codigoPais = new IdentificationCodeType();
            codigoPais.listName = "Country";
            codigoPais.listAgencyName = "United Nations Economic Commission for Europe";
            codigoPais.listID = "ISO 3166-1";
            codigoPais.Value = "PE";
            pais.IdentificationCode = codigoPais;
            direccionPL.Country = pais;
            partelegal.RegistrationAddress = direccionPL;
            partelegals.Add(partelegal);
            party.PartyLegalEntity = partelegals.ToArray();
            ////Agregando sublistas
            party.PartyIdentification = partyidentificacionsN;
            party.PartyName = partynames.ToArray();
            empresa.Party = party;
            Factura.AccountingSupplierParty = empresa;

            //Empresa receptora (Cliente)
            CustomerPartyType cliente = new CustomerPartyType();
            PartyType partyCliente = new PartyType();
            List<PartyIdentificationType> partyIdentificationClientes = new List<PartyIdentificationType>();
            PartyIdentificationType partyIdentificationCliente = new PartyIdentificationType();
            IDType idtipoCliente = new IDType();

            if (clsCliente.cDocumento.Length == 11)
            {
                clsCliente.TiDocumentoSunat = "6";
            }
            else if (clsCliente.cDocumento.Length == 8)
            {
                clsCliente.TiDocumentoSunat = "1";
                //clsCliente.cDireccion = "-";
            }
            else
            {
                clsCliente.TiDocumentoSunat = "-";
                clsCliente.cDocumento = "-";
                clsCliente.cCliente = "![CDATA[-]]";
                clsCliente.cDireccion = "-";
            }
            idtipoCliente.schemeID = clsCliente.TiDocumentoSunat;
            idtipoCliente.schemeName = "Documento de Identidad";
            idtipoCliente.schemeAgencyName = "PE:SUNAT";
            idtipoCliente.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
            idtipoCliente.Value = clsCliente.cDocumento;//EmpresaRUCcliente;
            partyIdentificationCliente.ID = idtipoCliente;
            partyIdentificationClientes.Add(partyIdentificationCliente);
            partyCliente.PartyIdentification = partyIdentificationClientes.ToArray();

            ////Razon social cliente
            List<PartyLegalEntityType> partylegalClientes = new List<PartyLegalEntityType>();
            PartyLegalEntityType partylegalCliente = new PartyLegalEntityType();
            RegistrationNameType razonsocialcliente = new RegistrationNameType();
            razonsocialcliente.Value = clsCliente.cCliente;//EmpresaRazonsocialCliente;
            partylegalCliente.RegistrationName = razonsocialcliente;
            ////Direccion del cliente (OPCIONAL)
            AddressType direccionclienteType = new AddressType();
            List<AddressLineType> direccionclientes = new List<AddressLineType>();
            AddressLineType direccioncliente = new AddressLineType();
            List<LineType> lineas = new List<LineType>();
            LineType linea = new LineType();
            linea.Value = clsCliente.cDireccion;//DireccionCliente;
            direccioncliente.Line = linea;
            direccionclientes.Add(direccioncliente);
            direccionclienteType.AddressLine = direccionclientes.ToArray();
            partylegalClientes.Add(partylegalCliente);
            partyCliente.PartyLegalEntity = partylegalClientes.ToArray();
            cliente.Party = partyCliente;
            Factura.AccountingCustomerParty = cliente;

            #region <cac:PaymentTerms> Forma de pago
            PaymentTermsType tipopago = new PaymentTermsType();
            PaymentTermsType[] tipopagos = new PaymentTermsType[2];
            IDType idpago = new IDType();
            idpago.Value = "FormaPago";
            tipopago.ID = idpago;

            PaymentMeansIDType formapago = new PaymentMeansIDType();
            PaymentMeansIDType[] formapagos = new PaymentMeansIDType[1];
            formapago.Value = "Contado";
            formapagos[0] = formapago;
            tipopago.PaymentMeansID = formapagos;

            tipopagos[0] = tipopago;
            Factura.PaymentTerms = tipopagos;
            #endregion

            #region <cac:TaxTotal> IMPUESTOS AL TOTAL
            //<cac:TaxTotal>
            ////<cbc:TaxAmount
            TaxTotalType TotalImptos = new TaxTotalType();
            List<TaxTotalType> TotalImptosLista = new List<TaxTotalType>();

            TaxAmountType taxAmountImpto = new TaxAmountType();
            taxAmountImpto.currencyID = "PEN";
            taxAmountImpto.Value = Math.Round(paramFactura.TotalIgv, 2);
            TotalImptos.TaxAmount = taxAmountImpto;
            ////</cbc:TaxAmount>
            
            ////<cac:TaxSubtotal>
            List<TaxSubtotalType> subtotales = new List<TaxSubtotalType>();
            TaxSubtotalType subtotal = new TaxSubtotalType();

            //////<cbc:TaxableAmount
            TaxableAmountType taxsubtotal = new TaxableAmountType();
            taxsubtotal.currencyID = "PEN";
            taxsubtotal.Value = Math.Round(paramFactura.TotSubtotal, 2);
            subtotal.TaxableAmount = taxsubtotal;
            //////</cbc:TaxableAmount>

            //////<cbc:TaxAmount
            TaxAmountType TotalTaxAmountTotal = new TaxAmountType();
            TotalTaxAmountTotal.currencyID = "PEN";
            TotalTaxAmountTotal.Value = Math.Round(paramFactura.TotalIgv, 2);
            subtotal.TaxAmount = TotalTaxAmountTotal;
            //subtotales.Add(subtotal);
            //TotalImptos.TaxSubtotal = subtotales.ToArray();
            //////</cbc:TaxAmount>

            //////<cac:TaxCategory>
            TaxCategoryType taxcategoryTotal = new TaxCategoryType();
            ////////<cac:TaxScheme>
            IDType iDType = new IDType();
            iDType.schemeAgencyName = "United Nations Economic Commission for Europe";
            iDType.schemeID = "UN/ECE 5305";
            iDType.schemeName = "Tax Category Identifier";
            iDType.Value = "S";
            taxcategoryTotal.ID = iDType;

            TaxSchemeType taxScheme = new TaxSchemeType();
            //////////<cbc:ID
            IDType idtotal = new IDType();
            idtotal.schemeName = "Codigo de tributos";
            idtotal.schemeAgencyName = "PE:SUNAT";
            idtotal.schemeID = "UN/ECE 5153";
            idtotal.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo05";
            idtotal.Value = "1000";
            taxScheme.ID = idtotal;
            //////////</cbc:ID>
            //////////<cbc:Name>
            NameType1 nombreImpuesto = new NameType1();
            nombreImpuesto.Value = "IGV";
            taxScheme.Name = nombreImpuesto;
            //////////</cbc:Name>
            //////////<cbc:TaxTypeCode>
            TaxTypeCodeType taxtypecodeImpto = new TaxTypeCodeType();
            taxtypecodeImpto.Value = "VAT";
            taxScheme.TaxTypeCode = taxtypecodeImpto;
            //////////<cbc:TaxTypeCode>
            ////////</cac:TaxScheme>
            taxcategoryTotal.TaxScheme = taxScheme;
            //////</cac:TaxCategory>
            subtotal.TaxCategory = taxcategoryTotal;
            ////</cac:TaxSubtotal>
            subtotales.Add(subtotal);
            #region Impuesto por bolsa
            //foreach (DetalleVenta det in lstDetalleVentas)
            //{
            //    //if (det.Codigo.Contains("BBBB"))
            //    //{
            //        TaxSubtotalType TotalICBPER = new TaxSubtotalType();
            //        TaxAmountType taxICBPER = new TaxAmountType();
            //        taxICBPER.currencyID = "PEN";
            //        taxICBPER.Value = Math.Round((det.Cantidad * det.preciounitario), 2);
            //        TotalICBPER.TaxAmount = taxICBPER;
            //        TaxCategoryType taxCategoria = new TaxCategoryType();
            //        TaxSchemeType taxSchemaicb = new TaxSchemeType();
            //        IDType idTaschema = new IDType();
            //        idTaschema.Value = "7152";
            //        NameType1 nombreICB = new NameType1();
            //        nombreICB.Value = "ICBPER";
            //        TaxTypeCodeType taxtypecodeICPER = new TaxTypeCodeType();
            //        taxtypecodeICPER.Value = "OTH";

            //        taxSchemaicb.ID = idTaschema;
            //        taxSchemaicb.Name = nombreICB;
            //        taxSchemaicb.TaxTypeCode = taxtypecodeICPER;

            //        taxCategoria.TaxScheme = taxSchemaicb;

            //        TotalICBPER.TaxCategory = taxCategoria;
            //        subtotales.Add(TotalICBPER);
            //        break;
            //    //}

            //}
            #endregion

            TotalImptos.TaxSubtotal = subtotales.ToArray();
            TotalImptosLista.Add(TotalImptos);
            Factura.TaxTotal = TotalImptosLista.ToArray();

            FreeOfChargeIndicatorType freeOfChargeIndicatorTypeS = new FreeOfChargeIndicatorType();
            freeOfChargeIndicatorTypeS.Value = false;

            AllowanceChargeType[] allowanceChargeTypeS = new AllowanceChargeType[1];
            AllowanceChargeReasonCodeType allowanceChargeReasonCodeTypeS = new AllowanceChargeReasonCodeType();
            ChargeIndicatorType chargeIndicatorTypeS = new ChargeIndicatorType();
            AmountType2 amountTypeS = new AmountType2();
            amountTypeS.currencyID = "PEN";
            amountTypeS.Value = Math.Round(Convert.ToDecimal(paramFactura.TotalDescuento) / (1 + 0.18m), 2);

            allowanceChargeTypeS[0] = new AllowanceChargeType();

            allowanceChargeReasonCodeTypeS.Value = "00";
            allowanceChargeTypeS[0].AllowanceChargeReasonCode = allowanceChargeReasonCodeTypeS;
            chargeIndicatorTypeS.Value = false;

            allowanceChargeTypeS[0].Amount = amountTypeS;
            allowanceChargeTypeS[0].ChargeIndicator = chargeIndicatorTypeS;

            //Factura.AllowanceCharge = allowanceChargeTypeS;

            //</cac:TaxTotal>
            #endregion
            #region <cac:LegalMonetaryTotal> TOTALES
            MonetaryTotalType TotalValorVenta = new MonetaryTotalType();

            LineExtensionAmountType lineExtensionAmount = new LineExtensionAmountType();
            lineExtensionAmount.currencyID = "PEN";
            Decimal tot = paramFactura.Monto_total;
            //lineExtensionAmount.Value = Math.Round((paramFactura.Monto_total + Convert.ToDecimal(lstDetalleVentas.Sum(i => i.TotalTipoDescuento)) / 1.18m), 2);
            lineExtensionAmount.Value = Math.Round(tot / 1.18m, 2);
            TotalValorVenta.LineExtensionAmount = lineExtensionAmount;

            TaxInclusiveAmountType taxInclusiveAmount = new TaxInclusiveAmountType();
            taxInclusiveAmount.currencyID = "PEN";
            taxInclusiveAmount.Value = Convert.ToDecimal(string.Format("{0:0.##}", paramFactura.Monto_total));
            TotalValorVenta.TaxInclusiveAmount = taxInclusiveAmount;

            AllowanceTotalAmountType allowanceTotalAmount = new AllowanceTotalAmountType();
            allowanceTotalAmount.currencyID = "PEN";
            allowanceTotalAmount.Value =0.00m ;//Math.Round(Convert.ToDecimal(lstDetalleVentas.Sum(i => i.TotalTipoDescuento)) / 1.18m, 2);
            
            TotalValorVenta.AllowanceTotalAmount = allowanceTotalAmount;


            ChargeTotalAmountType chargeTotalAmount = new ChargeTotalAmountType();
            chargeTotalAmount.currencyID = "PEN";
            chargeTotalAmount.Value = 0.00m;
            TotalValorVenta.ChargeTotalAmount = chargeTotalAmount;

            PrepaidAmountType prepaidAmount = new PrepaidAmountType();
            prepaidAmount.currencyID = "PEN";
            prepaidAmount.Value = 0.00m;
            TotalValorVenta.PrepaidAmount = prepaidAmount;

            PayableRoundingAmountType payableRoundingAmountType = new PayableRoundingAmountType();
            payableRoundingAmountType.currencyID = "PEN";
            payableRoundingAmountType.Value = Convert.ToDecimal(string.Format("{0:0.##}", paramFactura.TotRedondeo));
            TotalValorVenta.PayableRoundingAmount= payableRoundingAmountType;

            PayableAmountType payableAmount = new PayableAmountType();
            payableAmount.currencyID = "PEN";
            payableAmount.Value = Convert.ToDecimal(string.Format("{0:0.##}", paramFactura.Monto_total+ paramFactura.TotRedondeo));
            TotalValorVenta.PayableAmount = payableAmount;

            Factura.LegalMonetaryTotal = TotalValorVenta;

           

            

            #endregion
            #region <cac:InvoiceLine> PRODUCTOS DE LA FACTURA
            List<InvoiceLineType> items = new List<InvoiceLineType>();
            int idtem = 1;
            foreach (DetalleVenta detalle in lstDetalleVentas)
            {

                //Calcular el valor del descuento a aplicar al precio unitario del producto:
                decimal descuento = Convert.ToDecimal(detalle.TotalTipoDescuento);
                decimal descuento_Sin_Igv = Convert.ToDecimal(detalle.TotalTipoDescuento) / 1.18m;

                //Restar el valor del descuento al precio unitario del producto:
                Decimal resta = detalle.preciounitario - detalle.importeRestante;
                decimal precio_unitario_Sin_Igv = resta==0? detalle.preciounitario / 1.18m :(detalle.preciounitario) / 1.18m;
                decimal precio_unitario_descuento = resta == 0 ? detalle.preciounitario -descuento:(detalle.preciounitario) - descuento;

                //Calcular el valor del precio unitario sin el IGV:
                decimal precio_unitario_descuento_sin_igv = precio_unitario_descuento / 1.18m;

                InvoiceLineType item = new InvoiceLineType();

                IDType numeroItem = new IDType();
                numeroItem.Value = idtem.ToString();
                item.ID = numeroItem;

                InvoicedQuantityType cantidad = new InvoicedQuantityType();
                cantidad.unitCode = detalle.Unidad_de_medida;
                cantidad.unitCodeListID = "UN/ECE rec 20";
                cantidad.unitCodeListAgencyName = "United Nations Economic Commission for Europe";
                cantidad.Value = Convert.ToDecimal(string.Format("{0:0.00}", detalle.Cantidad));;
                item.InvoicedQuantity = cantidad;

                LineExtensionAmountType ValorVenta = new LineExtensionAmountType();
                ValorVenta.currencyID = "PEN";
                ValorVenta.Value = Math.Round((precio_unitario_descuento_sin_igv),2);
                item.LineExtensionAmount = ValorVenta;

                FreeOfChargeIndicatorType freeOfChargeIndicatorType = new FreeOfChargeIndicatorType();
                freeOfChargeIndicatorType.Value = false;
                item.FreeOfChargeIndicator = freeOfChargeIndicatorType;

                
                PricingReferenceType ValorReferenUnitario = new PricingReferenceType();
                List<PriceType> TipoPrecios = new List<PriceType>();
                PriceType TipoPrecio = new PriceType();
                PriceAmountType PrecioMonto = new PriceAmountType();
                PrecioMonto.currencyID = "PEN";
                PrecioMonto.Value = Convert.ToDecimal(string.Format("{0:0.00}", precio_unitario_descuento));
                TipoPrecio.PriceAmount = PrecioMonto;

                PriceTypeCodeType TipoPrecioCode = new PriceTypeCodeType();
                TipoPrecioCode.listName = "Tipo de Precio";
                TipoPrecioCode.listAgencyName = "PE:SUNAT";
                TipoPrecioCode.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16";
                TipoPrecioCode.Value = "01";
                TipoPrecio.PriceTypeCode = TipoPrecioCode;

                TipoPrecios.Add(TipoPrecio);

                ValorReferenUnitario.AlternativeConditionPrice = TipoPrecios.ToArray();
                item.PricingReference = ValorReferenUnitario;

                AllowanceChargeType[] allowanceChargeType = new AllowanceChargeType[1];
                AllowanceChargeReasonCodeType allowanceChargeReasonCodeType = new AllowanceChargeReasonCodeType();
                allowanceChargeReasonCodeType.Value = "00";
                ChargeIndicatorType chargeIndicatorType = new ChargeIndicatorType();
                chargeIndicatorType.Value = false;
                MultiplierFactorNumericType multiplierFactorNumericType = new MultiplierFactorNumericType();
                multiplierFactorNumericType.Value = detalle.IdTipoDescuento==2? Math.Round(Convert.ToDecimal(detalle.TotalTipoDescuento)/detalle.preciounitario,2): Math.Round((Convert.ToDecimal(detalle.Descuento) / 100),2);
                BaseAmountType baseAmountType = new BaseAmountType();
                baseAmountType.currencyID = "PEN";
                baseAmountType.Value = Math.Round(Convert.ToDecimal(precio_unitario_Sin_Igv),2);
                AmountType2 amountType = new AmountType2();
                amountType.currencyID = "PEN";
                //amountType.Value = Convert.ToDecimal(string.Format("{0:0.00}", Convert.ToDecimal(detalle.TotalTipoDescuento) / (1 + 0.18m)));
                amountType.Value = Math.Round(Convert.ToDecimal(detalle.TotalTipoDescuento) / (1.18m),2);
                allowanceChargeType[0] = new AllowanceChargeType();

                
                allowanceChargeType[0].AllowanceChargeReasonCode = allowanceChargeReasonCodeType;
                

                allowanceChargeType[0].ChargeIndicator = chargeIndicatorType;
                allowanceChargeType[0].Amount = amountType;
                allowanceChargeType[0].MultiplierFactorNumeric = multiplierFactorNumericType;
                allowanceChargeType[0].BaseAmount = baseAmountType;
                item.AllowanceCharge = allowanceChargeType;

                decimal dcSubtotal = precio_unitario_descuento_sin_igv;
                //Decimal dcSubtotal = Convert.ToDecimal(detalle.preciounitario /*- Convert.ToDecimal(detalle.TotalTipoDescuento)*/) / (1.18m);
                decimal total_igv = dcSubtotal * 0.18m;

                decimal total = dcSubtotal + total_igv;

                List<TaxTotalType> Totales_Items = new List<TaxTotalType>();
                TaxTotalType Totales_Item = new TaxTotalType();
                TaxAmountType Total_Item = new TaxAmountType();
                Total_Item.currencyID = "PEN";
                //Total_Item.Value = Convert.ToDecimal(string.Format("{0:0.##}", total));
                Total_Item.Value = Math.Round(total_igv, 2);
                Totales_Item.TaxAmount = Total_Item;

                //List<TaxSubtotalType> subtotal_Items = new List<TaxSubtotalType>();
                //TaxSubtotalType subtotal_Item = new TaxSubtotalType();
                //TaxableAmountType taxsubtotal_IGVItem = new TaxableAmountType();
                //taxsubtotal_IGVItem.currencyID = "PEN";
                //taxsubtotal_IGVItem.Value = Convert.ToDecimal(string.Format("{0:0.###}", dcSubtotal));
                //subtotal_Item.TaxableAmount = taxsubtotal_IGVItem;

                //TaxAmountType TotalTaxAmount_IGVItem = new TaxAmountType();
                //TotalTaxAmount_IGVItem.currencyID = "PEN";
                //TotalTaxAmount_IGVItem.Value = Convert.ToDecimal(string.Format("{0:0.###}",0));
                //subtotal_Item.TaxAmount = TotalTaxAmount_IGVItem;
                

                //TaxCategoryType taxcategory_IGVItem = new TaxCategoryType();
                //IDType iDType1= new IDType();
                //iDType1.schemeAgencyName = "United Nations Economic Commission for Europe";
                //iDType1.schemeID = "UN/ECE 5305";
                //iDType1.schemeName = "Tax Category Identifier";
                //iDType1.Value = "S";
                //taxcategory_IGVItem.ID = iDType1;

                //PercentType1 porcentaje = new PercentType1();
                //porcentaje.Value = Convert.ToDecimal(string.Format("{0:0.00}", 00));
                //taxcategory_IGVItem.Percent = porcentaje;

                //TierRangeType tierRangeType1 = new TierRangeType();
                //tierRangeType1.Value = "0";
                //subtotal_Item.TierRange=tierRangeType1;

                //TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                //IDType iDType2= new IDType();
                //iDType2.schemeAgencyName = "PE:SUNAT";
                //iDType2.schemeID = "UN/ECE 5153";
                //iDType2.schemeName = "Codigo de tributos";
                //iDType2.Value = "2000";
                //taxSchemeType1.ID= iDType2;

                //NameType1 nameType1 = new NameType1();
                //nameType1.Value = "ISC";
                //taxSchemeType1.Name = nameType1;

                //TaxTypeCodeType taxTypeCodeType = new TaxTypeCodeType();
                //taxTypeCodeType.Value = "EXC";
                //taxSchemeType1.TaxTypeCode = taxTypeCodeType;
                //taxcategory_IGVItem.TaxScheme= taxSchemeType1;

                //subtotal_Item.TaxCategory = taxcategory_IGVItem;
                //subtotal_Items.Add(subtotal_Item);

                //Totales_Item.TaxSubtotal = subtotal_Items.ToArray();

                //< !--Excluyentes::Otro Tributo - Gratuita(Bonificacion) - Exportacion - Onerosa(Bonitificacion) { Gravada, Inafecta, Exonerada} -->

                List<TaxSubtotalType> taxSubtotalTypes = new List<TaxSubtotalType>();
                TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                taxableAmountType1.currencyID = "PEN";
                taxableAmountType1.Value = Math.Round(dcSubtotal, 2);
                taxSubtotalType1.TaxableAmount = taxableAmountType1;

                TaxAmountType taxAmountType2 = new TaxAmountType();
                taxAmountType2.currencyID = "PEN";
                taxAmountType2.Value = Math.Round(total_igv, 2);
                taxSubtotalType1.TaxAmount = taxAmountType2;


                TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                IDType iDType3 = new IDType();
                iDType3.schemeAgencyName = "United Nations Economic Commission for Europe";
                iDType3.schemeID = "UN/ECE 5305";
                iDType3.schemeName = "Tax Category Identifier";
                iDType3.Value = "S";
                taxCategoryType1.ID = iDType3;

                PercentType1 percentType1 = new PercentType1();
                percentType1.Value = Convert.ToDecimal(string.Format("{0:0.00}", 18));
                taxCategoryType1.Percent = percentType1;

                TaxExemptionReasonCodeType ReasonCode = new TaxExemptionReasonCodeType();
                ReasonCode.listAgencyName = "PE:SUNAT";
                ReasonCode.listName = "Afectacion del IGV";
                ReasonCode.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                ReasonCode.Value = "10";
                taxCategoryType1.TaxExemptionReasonCode = ReasonCode;


                TaxSchemeType taxSchemeType2 = new TaxSchemeType();
                IDType iDType4 = new IDType();
                iDType4.schemeAgencyName = "PE:SUNAT";
                iDType4.schemeID = "UN/ECE 5153";
                iDType4.schemeName = "Codigo de tributos";
                iDType4.Value = "1000";
                taxSchemeType2.ID = iDType4;

                NameType1 nameType11 = new NameType1();
                nameType11.Value = "IGV";
                taxSchemeType2.Name = nameType11;

                TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                taxTypeCodeType1.Value = "VAT";
                taxSchemeType2.TaxTypeCode = taxTypeCodeType1;

                taxCategoryType1.TaxScheme = taxSchemeType2;

                taxSubtotalType1.TaxCategory = taxCategoryType1;
                taxSubtotalTypes.Add(taxSubtotalType1);

                Totales_Item.TaxSubtotal = taxSubtotalTypes.ToArray();

                Totales_Items.Add(Totales_Item);

                item.TaxTotal = Totales_Items.ToArray();

                ItemType itemTipo = new ItemType();
                DescriptionType description = new DescriptionType();
                List<DescriptionType> descriptions = new List<DescriptionType>();
                description.Value = detalle.Descripcion;
                descriptions.Add(description);

                ItemIdentificationType codigoProd = new ItemIdentificationType();
                IDType id = new IDType();
                id.Value = detalle.CodigoProducto;//detalle.Codigo;
                codigoProd.ID = id;
                itemTipo.Description = descriptions.ToArray();
                itemTipo.SellersItemIdentification = codigoProd;

                List<CommodityClassificationType> codSunats = new List<CommodityClassificationType>();
                CommodityClassificationType codSunat = new CommodityClassificationType();
                ItemClassificationCodeType codClas = new ItemClassificationCodeType();
                codClas.listID = "UNSPSC";
                codClas.listAgencyName = "GS1 US";
                codClas.listName = "Item Classification";
                codClas.Value = "25172405";
                codSunat.ItemClassificationCode = codClas;
                codSunats.Add(codSunat);
                itemTipo.CommodityClassification = codSunats.ToArray();


                PriceType PrecioProducto = new PriceType();
                PriceAmountType PrecioMontoTipo = new PriceAmountType();
                PrecioMontoTipo.currencyID = "PEN";
                decimal porcentajeIgv = Convert.ToDecimal(paramFactura.Porcentaje_IGV / 100);

                PrecioMontoTipo.Value = Math.Round(precio_unitario_Sin_Igv, 2);
                PrecioProducto.PriceAmount = PrecioMontoTipo;


                item.Item = itemTipo;
                item.Price = PrecioProducto;
                
                items.Add(item);
                idtem += 1;
            }
            Factura.InvoiceLine = items.ToArray();

            #endregion
            string rutaxml = CrearArchivoxml(Factura, Variables.claseEmpresa.Ruc, paramFactura.CodigoComprobante, paramFactura.Serie, paramFactura.Correlativo);
            FirmarXML(rutaxml, Ruta_Certificado, Password_Certificado);
            string rutaenvio = RutaEnvios + Path.GetFileName(rutaxml).Replace(".xml", ".zip");
            //fnConvertiraPdf(rutaxml);
            ComprimirZip(rutaxml, rutaenvio);
            return Enviardocumento(rutaenvio);
        }


        private string CrearArchivoxml(InvoiceType Factura, string RUCEmisor, string CodigoTipoComprobante, string serie, string correlativo)
        {
            //Generar el archivo xml
            XmlWriterSettings propiedades = new XmlWriterSettings();
            propiedades.Indent = true;
            propiedades.IndentChars = "\t";
            string Nombrearchivoxml = RUCEmisor + "-" + CodigoTipoComprobante + "-" + serie + "-" + correlativo;
            string rutaxml = string.Format(@"{0}{1}.xml", Rutaxml, Nombrearchivoxml);
            using (XmlWriter escribir = XmlWriter.Create(rutaxml, propiedades))
            {
                Type serializacion = typeof(InvoiceType);
                XmlSerializer crearxml = new XmlSerializer(serializacion);
                crearxml.Serialize(escribir, Factura);
                return rutaxml;
            }
        }

       
        public string FirmarXML(string cRutaArchivo, string cCertificado, string cClave)
        {

            string file = cRutaArchivo;
            string text = File.ReadAllText(file);
            text = text.Replace(@"<ext:UBLExtension />", @"<ext:UBLExtension> <ext:ExtensionContent /></ext:UBLExtension>");
            text = text.Replace("xsi:type=", "");
            text = text.Replace("cbc:SerialIDType", "");
            text = text.Replace("\"\"", "");
            File.WriteAllText(file, text);
            string cRpta;
            string tipo = Path.GetFileName(cRutaArchivo);

            string local_typoDocumento = tipo.Substring(12, 2);
            string l_xpath = "";
            string f_certificat = cCertificado;
            string f_pwd = cClave;
            string xmlFile = cRutaArchivo;

            try
            {
                X509Certificate2 MonCertificat = new X509Certificate2(f_certificat, f_pwd);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.Load(xmlFile);

                SignedXml signedXml = new SignedXml(xmlDoc);
                signedXml.SigningKey = MonCertificat.PrivateKey;
                signedXml.SignedInfo.SignatureMethod = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";

                KeyInfo KeyInfo = new KeyInfo();
                Reference Reference = new Reference();
                Reference.Uri = "";
                Reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
                signedXml.AddReference(Reference);
                X509Chain X509Chain = new X509Chain();
                X509Chain.Build(MonCertificat);
                X509ChainElement local_element = X509Chain.ChainElements[0];
                KeyInfoX509Data x509Data = new KeyInfoX509Data(local_element.Certificate);
                string subjectName = local_element.Certificate.Subject;
                x509Data.AddSubjectName(subjectName);
                KeyInfo.AddClause(x509Data);
                signedXml.KeyInfo = KeyInfo;

                signedXml.ComputeSignature();

                XmlElement signature = signedXml.GetXml();
                signature.Prefix = "ds";

                signedXml.ComputeSignature();
                foreach (XmlNode node in signature.SelectNodes("descendant-or-self::*[namespace-uri()='http://www.w3.org/2000/09/xmldsig#']"))
                {

                    if (node.LocalName == "Signature")
                    {
                        XmlAttribute newAttribute = xmlDoc.CreateAttribute("Id");
                        newAttribute.Value = "SignSUNAT";
                        node.Attributes.Append(newAttribute);
                    }
                }
                XmlNamespaceManager nsMgr;
                nsMgr = new XmlNamespaceManager(xmlDoc.NameTable);
                nsMgr.AddNamespace("sac", "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1");
                nsMgr.AddNamespace("ccts", "urn:un:unece:uncefact:documentation:2");
                nsMgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");

                switch (local_typoDocumento)
                {
                    case "01":
                    case "02":
                    case "03"// factura y boleta
                   :
                        {
                            nsMgr.AddNamespace("tns", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2");
                            l_xpath = "/tns:Invoice/ext:UBLExtensions/ext:UBLExtension[1]/ext:ExtensionContent";
                            break;
                        }

                    case "07" // nota de credito
             :
                        {
                            nsMgr.AddNamespace("tns", "urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2");
                            l_xpath = "/tns:CreditNote/ext:UBLExtensions/ext:UBLExtension[1]/ext:ExtensionContent";
                            break;
                        }

                    case "08" // nota de debito
                        :
                        {
                            nsMgr.AddNamespace("tns", "urn:oasis:names:specification:ubl:schema:xsd:DebitNote-2");
                            l_xpath = "/tns:DebitNote/ext:UBLExtensions/ext:UBLExtension[1]/ext:ExtensionContent";
                            break;
                        }
                    case "RA" // Comunicacion de baja
                   :
                        {
                            nsMgr.AddNamespace("tns", "urn:sunat:names:specification:ubl:peru:schema:xsd:VoidedDocuments-1");
                            l_xpath = "/tns:VoidedDocuments/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent";
                            break;
                        }
                    case "RC" // Resumen diario
                    :
                        {
                            nsMgr.AddNamespace("tns", "urn:sunat:names:specification:ubl:peru:schema:xsd:SummaryDocuments-1");
                            l_xpath = "/tns:SummaryDocuments/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent";

                            break;
                        }

                }
                nsMgr.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
                nsMgr.AddNamespace("udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2");
                nsMgr.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
                nsMgr.AddNamespace("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2");
                nsMgr.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
                nsMgr.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#");
                xmlDoc.SelectSingleNode(l_xpath, nsMgr).AppendChild(xmlDoc.ImportNode(signature, true));
                xmlDoc.Save(xmlFile);
                XmlNodeList nodeList = xmlDoc.GetElementsByTagName("ds:Signature");
                if (nodeList.Count != 1)
                {
                    MessageBox.Show("Problemas con la firma");
                    cRpta = "Problemas con la firma";
                }
                signedXml.LoadXml((XmlElement)nodeList[0]);
                if (signedXml.CheckSignature() == false)
                    cRpta = "No se logro firmar el comprobante";
                else
                    cRpta = "OK";
                return cRpta;
            }
            catch (Exception ex)
            {

                throw;
            }

            
        }
        public string ComprimirZip(string nombrearchivo, string rutadestino)
        {
            Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile();
            zip.AddFile(nombrearchivo, "");
            zip.Save(rutadestino);
            string respuesta = "Listo";
            return respuesta;
        }
        public string[] Enviardocumento(string Archivo)
        {
            string filezip = Archivo;
            string filepath = filezip;
            byte[] bitArray = File.ReadAllBytes(filepath);
            try
            {
                EndpointAddress remoteAddress= new EndpointAddress("https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService");
                BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;
                binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                binding.Security.Message.AlgorithmSuite = System.ServiceModel.Security.SecurityAlgorithmSuite.Default;

                if (Variables.cNombreServidor != "365.database.windows.net")
                {
                    remoteAddress = new EndpointAddress("https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService");

                }
                else
                {
                    remoteAddress = new EndpointAddress("https://e-factura.sunat.gob.pe/ol-ti-itcpfegem/billService");

                }
                billServiceClient servicio = new billServiceClient(binding, remoteAddress);
                ServicePointManager.UseNagleAlgorithm = true;
                ServicePointManager.Expect100Continue = false;
                ServicePointManager.CheckCertificateRevocationList = true;
                if (Variables.cNombreServidor != "365.database.windows.net")
                {
                    servicio.ClientCredentials.UserName.UserName = "20602404863MODDATOS";
                    servicio.ClientCredentials.UserName.Password = "MODDATOS";
                }
                else
                {

                    servicio.ClientCredentials.UserName.UserName = "20602404863FACTURAS";
                    servicio.ClientCredentials.UserName.Password = "Mihusat1";
                }


                var elements = servicio.Endpoint.Binding.CreateBindingElements();
                elements.Find<SecurityBindingElement>().EnableUnsecuredResponse = true;
                servicio.Endpoint.Binding = new CustomBinding(elements);
                servicio.Open();
                filezip = Path.GetFileName(filezip);
                byte[] returByte = servicio.sendBill(filezip, bitArray, "0");

                servicio.Close();
                filezip = Path.GetFileName(filezip);
                FileStream fs = new FileStream(RutaCDR + "R-" + filezip, FileMode.Create);
                fs.Write(returByte, 0, returByte.Length);
                fs.Close();
                //MessageBox.Show("Archivo generado con exito");

                var respuesta = new EmitirFactura(); 
                return respuesta.ObtenerRespuestaZIPSunat(RutaCDR + "R-" + filezip);
            }
            catch (FaultException ex)
            {
                MessageBox.Show(ex.Code.Name);
                return null;
            }

        }

        #region Nota de credito
        public void GenerarNotaCredito(ParametrosFactura paramFactura, Cliente clsCliente, List<DetalleVenta> lstDetalleVentas)
        {

            //Cabecera del xml
            CreditNoteType Factura = new CreditNoteType();
            Factura.Cac = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2";
            Factura.Cbc = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2";
            Factura.Ccts = "urn:un:unece:uncefact:documentation:2";
            Factura.Ds = "http://www.w3.org/2000/09/xmldsig#";
            Factura.Ext = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2";
            Factura.Qdt = "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2";
            Factura.Udt = "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2";
            UBLExtensionType[] ublextensiones = new UBLExtensionType[11];
            UBLExtensionType ublExtension = new UBLExtensionType();
            ublextensiones[0] = ublExtension;
            Factura.UBLExtensions = ublextensiones;

            //Otorgamos la version UBL y la version del esquema del documento
            Factura.UBLVersionID = new UBLVersionIDType();
            Factura.UBLVersionID.Value = versionUbl;
            Factura.CustomizationID = new CustomizationIDType();
            Factura.CustomizationID.Value = versionEstruc;

            //Ingresar serie y numero de comprobante
            Factura.ID = new IDType();
            Factura.ID.Value = paramFactura.Serie + "-" + paramFactura.Correlativo;
            //Fecha de emision
            Factura.IssueDate = new IssueDateType();
            string fechaemision = Convert.ToDateTime(paramFactura.fecha_venta).ToString("yyyy-MM-dd");
            Factura.IssueDate.Value = Convert.ToDateTime(fechaemision);
            Factura.IssueTime = new IssueTimeType();
            string hora = Convert.ToDateTime(paramFactura.fecha_venta).ToString("HH:mm:ss");
            Factura.IssueTime.Value = Convert.ToDateTime(hora);

            NoteType Leyenda = new NoteType();
            Leyenda.languageLocaleID = "1000";
            Leyenda.Value = paramFactura.PrecioALetras;
            List<NoteType> notas = new List<NoteType>();

            NoteType Leyenda2 = new NoteType();
            Leyenda2.Value = "ERROR DE DESCUENTOS EN LA EMISION";

            notas.Add(Leyenda2);
            notas.Add(Leyenda);
            Factura.Note = notas.ToArray();

            //Tipo de moneda
            DocumentCurrencyCodeType moneda = new DocumentCurrencyCodeType();
            moneda.listID = "ISO 4217 Alpha";
            moneda.listName = "Currency";
            moneda.listAgencyName = "United Nations Economic Commission for Europe";
            moneda.Value = "PEN";
            Factura.DocumentCurrencyCode = moneda;


            #region Datos Exclusivos para nota de credito
            ResponseType DocumentoRel = new ResponseType();
            ResponseType[] DocumentoRels = new ResponseType[2];
            ReferenceIDType NumeroDocRel = new ReferenceIDType();
            NumeroDocRel.Value = paramFactura.Ref_Serie + "-" + paramFactura.Ref_Numero;
            ResponseCodeType TipoDocRel = new ResponseCodeType();
            TipoDocRel.Value = paramFactura.CodigoTipoNotacredito;
            DescriptionType Motivo = new DescriptionType();
            DescriptionType[] Motivos = new DescriptionType[2];
            Motivos[0] = Motivo;
            Motivo.Value = paramFactura.Ref_Motivo;
            DocumentoRel.ReferenceID = NumeroDocRel;
            DocumentoRel.ResponseCode = TipoDocRel;
            DocumentoRel.Description = Motivos;
            DocumentoRels[0] = DocumentoRel;
            Factura.DiscrepancyResponse = DocumentoRels;

            // comprobante a eliminar
            BillingReferenceType[] referencias = new BillingReferenceType[2];
            BillingReferenceType referencia = new BillingReferenceType();

            DocumentReferenceType documento = new DocumentReferenceType();
            IDType docRela = new IDType();
            IssueDateType issueDateType = new IssueDateType();
            issueDateType.Value = Convert.ToDateTime(Variables.gdFechaSis.ToString("yyyy-MM-dd"));
            docRela.Value = paramFactura.Ref_Serie + "-" + paramFactura.Ref_Numero;
            DocumentTypeCodeType TipoDocumentoRel = new DocumentTypeCodeType();
            TipoDocumentoRel.listAgencyName = "PE:SUNAT";
            TipoDocumentoRel.listName = "Tipo de Documento";
            TipoDocumentoRel.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01";
            DocumentTypeType documentTypeType = new DocumentTypeType();
            documentTypeType.Value = "FACTURA ELECTRONICA BASICA";
            TipoDocumentoRel.Value = paramFactura.Ref_TipoComprobante;
            documento.DocumentTypeCode = TipoDocumentoRel;
            documento.ID = docRela;
            documento.IssueDate = issueDateType;
            referencia.InvoiceDocumentReference = documento;
            referencias[0] = referencia;
            Factura.BillingReference = referencias;

            #endregion


            ////Cantidad de productos en el detalle de venta
            //LineCountNumericType numeroProductos = new LineCountNumericType();
            //numeroProductos.Value = paramFactura.contadorProductos;

            #region nuevo
            //Ingresar datos de la empresa emisora
            SignatureType Firma = new SignatureType();
            SignatureType[] Firmas = new SignatureType[2];

            PartyType partySign = new PartyType();
            ////Agregar el ruc Empresa emisora
            PartyIdentificationType partyIdentificacion = new PartyIdentificationType();
            PartyIdentificationType[] partyIdentificacions = new PartyIdentificationType[2];
            IDType idFirma = new IDType();
            idFirma.Value = paramFactura.Serie + "-" + paramFactura.Correlativo; ;//Variables.claseEmpresa.Ruc;
            Firma.ID = idFirma;

            IDType idFirma2 = new IDType();
            idFirma2.Value = Variables.claseEmpresa.Ruc;

            partyIdentificacion.ID = idFirma2;
            partyIdentificacions[0] = partyIdentificacion;
            partySign.PartyIdentification = partyIdentificacions;
            Firma.SignatoryParty = partySign;

            //////Agregar notas
            //NoteType Nota = new NoteType();
            //NoteType[] Notas = new NoteType[2];
            //Nota.Value = "Elaborado por HUSAT GPS";
            //Notas[0] = Nota;
            //Firma.Note = Notas;
            //////Ingresar la razon social de la empresa emisora
            PartyNameType partyName = new PartyNameType();
            PartyNameType[] partyNames = new PartyNameType[2];
            NameType1 RazonSocialFirma = new NameType1();
            RazonSocialFirma.Value = Variables.claseEmpresa.RazonSocial;
            partyName.Name = RazonSocialFirma;
            partyNames[0] = partyName;
            partySign.PartyName = partyNames;

            AttachmentType attachType = new AttachmentType();
            ExternalReferenceType externaReferencia = new ExternalReferenceType();
            URIType uri = new URIType();
            uri.Value = Variables.claseEmpresa.Ruc;
            externaReferencia.URI = uri;
            Firma.DigitalSignatureAttachment = attachType;

            attachType.ExternalReference = externaReferencia;
            Firma.DigitalSignatureAttachment = attachType;

            Firmas[0] = Firma;
            Factura.Signature = Firmas;
            //Codigo del documento de identidad de la empresa emisora
            SupplierPartyType empresa = new SupplierPartyType();
            PartyType party = new PartyType();
            PartyIdentificationType partyidentificacionN = new PartyIdentificationType();
            PartyIdentificationType[] partyidentificacionsN = new PartyIdentificationType[2];
            IDType idEmpresa = new IDType();

            idEmpresa.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
            idEmpresa.schemeName = "Documento de Identidad";
            idEmpresa.schemeID = "6";
            idEmpresa.schemeAgencyName = "PE:SUNAT";
            idEmpresa.Value = Variables.claseEmpresa.Ruc;

            partyidentificacionN.ID = idEmpresa;
            partyidentificacionsN[0] = partyidentificacionN;
            party.PartyIdentification = partyidentificacionsN;
            ////Razon social empresa
            PartyNameType partyname = new PartyNameType();
            List<PartyNameType> partynames = new List<PartyNameType>();
            NameType1 nameEmisor = new NameType1();
            nameEmisor.Value = Variables.claseEmpresa.RazonSocial;
            partyname.Name = nameEmisor;
            partynames.Add(partyname);
            party.PartyName = partynames.ToArray();

            ////Establecimientos anexos y direccion de empresa emisora
            //List<PartyLegalEntityType> partelegals = new List<PartyLegalEntityType>();
            //PartyLegalEntityType partelegal = new PartyLegalEntityType();

            RegistrationNameType registronombre = new RegistrationNameType();
            registronombre.Value = Variables.claseEmpresa.Ruc;

            //partelegal.RegistrationName = registronombre;
            //Direccion emisor 
            CompanyIDType compañia = new CompanyIDType();
            compañia.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
            compañia.schemeAgencyName = "PE:SUNAT";
            compañia.schemeName = "SUNAT:Identificador de Documento de Identidad";
            compañia.schemeID = "6";
            compañia.Value = Variables.claseEmpresa.Ruc;

            AddressType direccion = new AddressType();
            AddressTypeCodeType addrestypecode = new AddressTypeCodeType();
            addrestypecode.listName = "Establecimientos anexos";
            addrestypecode.listAgencyName = "PE:SUNAT";
            addrestypecode.Value = "0000";

            TaxSchemeType taxSchema = new TaxSchemeType();
            IDType idsupplier = new IDType();
            idsupplier.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
            idsupplier.schemeAgencyName = "PE:SUNAT";
            idsupplier.schemeName = "SUNAT:Identificador de Documento de Identidad";
            idsupplier.schemeID = "6";
            idsupplier.Value = Variables.claseEmpresa.Ruc;
            taxSchema.ID = idsupplier;


            List<PartyLegalEntityType> partelegals = new List<PartyLegalEntityType>();
            PartyLegalEntityType partelegal = new PartyLegalEntityType();
            RegistrationNameType registerNamePL = new RegistrationNameType();
            registerNamePL.Value = Variables.claseEmpresa.RazonSocial;
            partelegal.RegistrationName = registerNamePL;

            
            AddressType direccionPL = new AddressType();
            IDType iddireccionPL = new IDType();
            iddireccionPL.schemeAgencyName = "PE:INEI";
            iddireccionPL.schemeName = "Ubigeos";
            iddireccionPL.Value = Variables.claseEmpresa.CodDepartamento + Variables.claseEmpresa.CodProvincia + Variables.claseEmpresa.CodDistrito;
            direccionPL.ID = iddireccionPL;

            AddressTypeCodeType address_TypeCodeType = new AddressTypeCodeType();
            address_TypeCodeType.listName = "Establecimientos anexos";
            address_TypeCodeType.listAgencyName = "PE:SUNAT";
            address_TypeCodeType.Value = "0000";
            direccionPL.AddressTypeCode = address_TypeCodeType;

            ////Indicar direccion fiscal de la empresa emisora
            CityNameType Departamento = new CityNameType();
            Departamento.Value = Variables.claseEmpresa.NomDepartamento;
            direccionPL.CityName = Departamento;

            CountrySubentityType provincia = new CountrySubentityType();
            provincia.Value = Variables.claseEmpresa.NomProvincia;
            direccionPL.CountrySubentity = provincia;

            DistrictType distrito = new DistrictType();
            distrito.Value = Variables.claseEmpresa.NomDistrito;
            direccionPL.District = distrito;
            List<AddressLineType> direcciones = new List<AddressLineType>();
            AddressLineType direccionEmisor = new AddressLineType();
            LineType datalocal = new LineType();
            datalocal.Value = Variables.claseEmpresa.Direccion;
            direccionPL.AddressLine = direcciones.ToArray();
            direccionEmisor.Line = datalocal;
            direcciones.Add(direccionEmisor);
            direccionPL.AddressLine = direcciones.ToArray();
            ////Pais empresa emisora
            CountryType pais = new CountryType();
            IdentificationCodeType codigoPais = new IdentificationCodeType();

            codigoPais.listName = "Country";
            codigoPais.listAgencyName = "United Nations Economic Commission for Europe";
            codigoPais.listID = "ISO 3166-1";
            codigoPais.Value = "PE";
            pais.IdentificationCode = codigoPais;

            direccionPL.Country = pais;
            partelegal.RegistrationAddress = direccionPL;

            partelegals.Add(partelegal);
            party.PartyLegalEntity = partelegals.ToArray();

            ////Agregando sublistas
            party.PartyName = partynames.ToArray();
            party.PartyIdentification = partyidentificacionsN;
            empresa.Party = party;
            Factura.AccountingSupplierParty = empresa;
            //xzczcz
            ////Empresa receptora (Cliente)
            //CustomerPartyType cliente = new CustomerPartyType();
            //PartyType partyCliente = new PartyType();
            //List<PartyIdentificationType> partyIdentificationClientes = new List<PartyIdentificationType>();
            //PartyIdentificationType partyIdentificationCliente = new PartyIdentificationType();
            //IDType idtipoCliente = new IDType();
            //idtipoCliente.schemeID = "6";
            //idtipoCliente.schemeName = "Documento de Identidad";
            //idtipoCliente.schemeAgencyName = "PE:SUNAT";
            //idtipoCliente.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
            //idtipoCliente.Value = clsCliente.cDocumento;//EmpresaRUCcliente;
            //partyIdentificationCliente.ID = idtipoCliente;
            //partyIdentificationClientes.Add(partyIdentificationCliente);
            //partyCliente.PartyIdentification = partyIdentificationClientes.ToArray();
            //////Razon social cliente
            //List<PartyLegalEntityType> partylegalClientes = new List<PartyLegalEntityType>();
            //PartyLegalEntityType partylegalCliente = new PartyLegalEntityType();
            //RegistrationNameType razonsocialcliente = new RegistrationNameType();
            //razonsocialcliente.Value = clsCliente.cCliente;//EmpresaRazonsocialCliente;
            //partylegalCliente.RegistrationName = razonsocialcliente;
            //////Direccion del cliente (OPCIONAL)
            //AddressType direccionclienteType = new AddressType();
            //List<AddressLineType> direccionclientes = new List<AddressLineType>();
            //AddressLineType direccioncliente = new AddressLineType();
            //List<LineType> lineas = new List<LineType>();
            //LineType linea = new LineType();
            //linea.Value = clsCliente.cDireccion;//DireccionCliente;
            //direccioncliente.Line = linea;
            //direccionclientes.Add(direccioncliente);
            //direccionclienteType.AddressLine = direccionclientes.ToArray();
            //partylegalClientes.Add(partylegalCliente);
            //partyCliente.PartyLegalEntity = partylegalClientes.ToArray();
            //cliente.Party = partyCliente;
            //Factura.AccountingCustomerParty = cliente;


            TaxSchemeType taxschemeCliente = new TaxSchemeType();
            CustomerPartyType CustomerPartyCliente = new CustomerPartyType();
            PartyType partyCliente = new PartyType();
            PartyIdentificationType partyIdentificion = new PartyIdentificationType();
            List<PartyIdentificationType> partyIdentificions = new List<PartyIdentificationType>();
            IDType idtipo = new IDType();
            idtipo.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
            idtipo.schemeName = "Documento de Identidad";
            idtipo.schemeAgencyName = "PE:SUNAT";
            idtipo.schemeID = "6";
            idtipo.Value = clsCliente.cDocumento;
            partyIdentificion.ID = idtipo;

            partyIdentificions.Add(partyIdentificion);
            partyCliente.PartyIdentification = partyIdentificions.ToArray();

            List<PartyNameType> RazSocClientes = new List<PartyNameType>();
            PartyNameType RazSocCliente = new PartyNameType();
            NameType1 razSocial = new NameType1();
            razSocial.Value = clsCliente.cCliente;
            RazSocCliente.Name = razSocial;
            RazSocClientes.Add(RazSocCliente);

            List<PartyTaxSchemeType> partySchemas = new List<PartyTaxSchemeType>();
            PartyTaxSchemeType partySchema = new PartyTaxSchemeType();
            RegistrationNameType RegistroNombre = new RegistrationNameType();
            RegistroNombre.Value = clsCliente.cCliente;
            partySchema.RegistrationName = RegistroNombre;

            CompanyIDType idcompañia = new CompanyIDType();
            idcompañia.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
            idcompañia.schemeAgencyName = "PE:SUNAT";
            idcompañia.schemeName = "SUNAT:Identificador de Documento de Identidad";
            idcompañia.schemeID = "6";
            idcompañia.Value = clsCliente.cDocumento;

            TaxSchemeType schemeType = new TaxSchemeType();
            IDType idc = new IDType();
            idc.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
            idc.schemeAgencyName = "PE:SUNAT";
            idc.schemeName = "SUNAT:Identificador de Documento de Identidad";
            idc.schemeID = "6";
            idc.Value = clsCliente.cDocumento;
            schemeType.ID = idc;

            idcompañia.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
            idcompañia.schemeAgencyName = "PE:SUNAT";
            idcompañia.schemeName = "SUNAT:Identificador de Documento de Identidad";
            idcompañia.schemeID = "6";
            idcompañia.Value = clsCliente.cDocumento;

            List<PartyLegalEntityType> partyLegals = new List<PartyLegalEntityType>();
            PartyLegalEntityType partyLegal = new PartyLegalEntityType();
            RegistrationNameType Registro_Nombre = new RegistrationNameType();
            Registro_Nombre.Value = clsCliente.cCliente;
            partyLegal.RegistrationName = Registro_Nombre;

            AddressType direccionCliente = new AddressType();
            List<AddressLineType> dirs = new List<AddressLineType>();
            AddressLineType dir = new AddressLineType();
            List<LineType> lineas = new List<LineType>();

            LineType linea = new LineType();
            linea.Value = clsCliente.cDireccion;
            dir.Line = linea;
            dirs.Add(dir);
            direccionCliente.AddressLine = dirs.ToArray();


            CountryType paisC = new CountryType();
            IdentificationCodeType codigoPaisC = new IdentificationCodeType();

            codigoPaisC.Value = "PE";
            paisC.IdentificationCode = codigoPaisC;

            partyLegals.Add(partyLegal);

            partySchema.CompanyID = idcompañia;
            partySchema.TaxScheme = schemeType;

            partySchemas.Add(partySchema);

            partyCliente.PartyLegalEntity = partyLegals.ToArray();
            CustomerPartyCliente.Party = partyCliente;

            CustomerPartyType accoutingCustomerParty = new CustomerPartyType();
            accoutingCustomerParty.Party = partyCliente;

            Factura.AccountingCustomerParty = accoutingCustomerParty;

            //Monto total de impuestos

            TaxTotalType TotalImptos = new TaxTotalType();
            TaxAmountType taxAmountImpto = new TaxAmountType();
            taxAmountImpto.currencyID = "PEN";
            taxAmountImpto.Value = Convert.ToDecimal(string.Format("{0:0.##}", paramFactura.TotalIgv));
            TotalImptos.TaxAmount = taxAmountImpto;

            TaxSubtotalType[] subtotales = new TaxSubtotalType[2];
            TaxSubtotalType subtotal = new TaxSubtotalType();

            TaxableAmountType taxsubtotal = new TaxableAmountType();
            taxsubtotal.currencyID = "PEN";
            taxsubtotal.Value = Convert.ToDecimal(string.Format("{0:0.##}", paramFactura.TotSubtotal));
            subtotal.TaxableAmount = taxsubtotal;

            TaxAmountType TotalTaxAmountTotal = new TaxAmountType();
            TotalTaxAmountTotal.currencyID = "PEN";
            TotalTaxAmountTotal.Value = Convert.ToDecimal(string.Format("{0:0.##}", paramFactura.TotalIgv));
            subtotal.TaxAmount = TotalTaxAmountTotal;

            TaxSubtotalType subTotalIGV = new TaxSubtotalType();
            subTotalIGV.TaxableAmount = taxsubtotal;

            subtotales[0] = subtotal;
            TotalImptos.TaxSubtotal = subtotales;


            //Pago de IGV
            TaxCategoryType taxcategoryTotal = new TaxCategoryType();
            TaxSchemeType taxScheme = new TaxSchemeType();
            IDType idTotal = new IDType();
            idTotal.schemeID = "UN/ECE 5305";
            idTotal.schemeName = "Tax Category Identifier";
            idTotal.schemeAgencyName = "United Nations Economic Commission for Europe";
            idTotal.Value = "S";

            NameType1 nametypeImpto = new NameType1();
            nametypeImpto.Value = "IGV";
            TaxTypeCodeType taxtypecodeImpto = new TaxTypeCodeType();
            taxtypecodeImpto.Value = "VAT";

            IDType idTot = new IDType();

            idTot.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo05";
            idTot.schemeAgencyName = "PE:SUNAT";
            idTot.schemeName = "Codigo de tributos";
            idTot.Value = "1000";
            taxScheme.ID = idTot;

            NameType1 nametypeImptoIGV = new NameType1();
            nametypeImptoIGV.Value = "IGV";
            TaxTypeCodeType taxtypecodeImpuesto = new TaxTypeCodeType();
            taxtypecodeImpuesto.Value = "VAT";

            taxScheme.Name = nametypeImpto;
            taxScheme.TaxTypeCode = taxtypecodeImpto;
            taxcategoryTotal.TaxScheme = taxScheme;
            subtotal.TaxCategory = taxcategoryTotal;

            List<TaxSubtotalType> TaxSubtotals = new List<TaxSubtotalType>();
            TaxSubtotals.Add(subtotal);
            TotalImptos.TaxSubtotal = TaxSubtotals.ToArray();

            List<TaxTotalType> taxTotals = new List<TaxTotalType>();

            taxTotals.Add(TotalImptos);
            Factura.TaxTotal = taxTotals.ToArray();



            #endregion
            #region <cac:LegalMonetaryTotal> TOTALES
            MonetaryTotalType TotalValorVenta = new MonetaryTotalType();
            LineExtensionAmountType lineExtensionAmount = new LineExtensionAmountType();

            lineExtensionAmount.currencyID = "PEN";
            lineExtensionAmount.Value = Convert.ToDecimal(string.Format("{0:0.##}", paramFactura.TotSubtotal));
            TotalValorVenta.LineExtensionAmount = lineExtensionAmount;

            TaxInclusiveAmountType taxInclusiveAmount = new TaxInclusiveAmountType();
            taxInclusiveAmount.currencyID = "PEN";
            taxInclusiveAmount.Value = Convert.ToDecimal(string.Format("{0:0.##}", paramFactura.Monto_total));
            //TotalValorVenta.TaxInclusiveAmount = taxInclusiveAmount;

            AllowanceTotalAmountType allowanceTotalAmount = new AllowanceTotalAmountType();
            allowanceTotalAmount.currencyID = "PEN";
            allowanceTotalAmount.Value = 0.00m;
            //TotalValorVenta.AllowanceTotalAmount = allowanceTotalAmount;

            ChargeTotalAmountType chargeTotalAmount = new ChargeTotalAmountType();
            chargeTotalAmount.currencyID = "PEN";
            chargeTotalAmount.Value = 0.00m;
            TotalValorVenta.ChargeTotalAmount = chargeTotalAmount;

            PrepaidAmountType prepaidAmount = new PrepaidAmountType();
            prepaidAmount.currencyID = "PEN";
            prepaidAmount.Value = 0.00m;
            TotalValorVenta.PrepaidAmount = prepaidAmount;      

            PayableAmountType payableAmount = new PayableAmountType();
            payableAmount.currencyID = "PEN";
            payableAmount.Value = Convert.ToDecimal(string.Format("{0:0.##}", (paramFactura.Monto_total-paramFactura.TotalDescuento)));

            TotalValorVenta.LineExtensionAmount = lineExtensionAmount;
            TotalValorVenta.TaxInclusiveAmount = taxInclusiveAmount;
            TotalValorVenta.AllowanceTotalAmount = allowanceTotalAmount;
            TotalValorVenta.ChargeTotalAmount = chargeTotalAmount;
            TotalValorVenta.PrepaidAmount = prepaidAmount;
            TotalValorVenta.PayableAmount = payableAmount;
            Factura.LegalMonetaryTotal = TotalValorVenta;

            #endregion
            #region <cac:InvoiceLine> PRODUCTOS DE LA FACTURA
            List<CreditNoteLineType> items = new List<CreditNoteLineType>();
            int idtem = 1;
            foreach (DetalleVenta detalle in lstDetalleVentas)
            {
                if (idtem==2)
                {
                    detalle.TotalTipoDescuento = 0;
                }
                CreditNoteLineType item = new CreditNoteLineType();
                IDType numeroItem = new IDType();
                numeroItem.Value = idtem.ToString();
                item.ID = numeroItem;

                CreditedQuantityType cantidad = new CreditedQuantityType();
                cantidad.unitCodeListAgencyName = "United Nations Economic Commission for Europe";
                cantidad.unitCodeListID = "UN/ECE rec 20";
                cantidad.unitCode = detalle.Unidad_de_medida;
                
                cantidad.Value = detalle.Cantidad;
                item.CreditedQuantity = cantidad;

                LineExtensionAmountType ValorVenta = new LineExtensionAmountType();
                ValorVenta.currencyID = "PEN";
                ValorVenta.Value = Convert.ToDecimal(string.Format("{0:0.##}", (detalle.preciounitario- Convert.ToDecimal(detalle.TotalTipoDescuento)) / (1 + 0.18m)));
                item.LineExtensionAmount = ValorVenta;

                //Precio de venta unitario por item y código 
                PricingReferenceType ValorReferenUnitario = new PricingReferenceType();

                List<PriceType> TipoPrecios = new List<PriceType>();
                PriceType TipoPrecio = new PriceType();
                PriceAmountType PrecioMonto = new PriceAmountType();
                PrecioMonto.currencyID = "PEN";
                PrecioMonto.Value = Convert.ToDecimal(string.Format("{0:0.##}", (detalle.preciounitario - Convert.ToDecimal(detalle.TotalTipoDescuento))));
                TipoPrecio.PriceAmount = PrecioMonto;

                PriceTypeCodeType TipoPrecioCode = new PriceTypeCodeType();
                TipoPrecioCode.listName = "Tipo de Precio";
                TipoPrecioCode.listAgencyName = "PE:SUNAT";
                TipoPrecioCode.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16";
                TipoPrecioCode.Value = "01";
                TipoPrecio.PriceTypeCode = TipoPrecioCode;

                TipoPrecios.Add(TipoPrecio);

                ValorReferenUnitario.AlternativeConditionPrice = TipoPrecios.ToArray();
                item.PricingReference = ValorReferenUnitario;

                Decimal dcSubtotal = (detalle.preciounitario - Convert.ToDecimal(detalle.TotalTipoDescuento)) / (1.18m);

                List<TaxTotalType> Totales_Items = new List<TaxTotalType>();
                TaxTotalType Totales_Item = new TaxTotalType();
                TaxAmountType Total_Item = new TaxAmountType();
                Total_Item.currencyID = "PEN";
                Total_Item.Value = Convert.ToDecimal(string.Format("{0:0.##}", dcSubtotal * (0.18m)));
                Totales_Item.TaxAmount = Total_Item;

                List<TaxSubtotalType> subtotal_Items = new List<TaxSubtotalType>();
                TaxSubtotalType subtotal_Item = new TaxSubtotalType();
                TaxableAmountType taxsubtotal_IGVItem = new TaxableAmountType();
                taxsubtotal_IGVItem.currencyID = "PEN";
                taxsubtotal_IGVItem.Value = Convert.ToDecimal(string.Format("{0:0.##}", dcSubtotal));
                subtotal_Item.TaxableAmount = taxsubtotal_IGVItem;

                TaxAmountType TotalTaxAmount_IGVItem = new TaxAmountType();
                TotalTaxAmount_IGVItem.currencyID = "PEN";
                TotalTaxAmount_IGVItem.Value = Convert.ToDecimal(string.Format("{0:0.##}", dcSubtotal * (0.18m)));
                subtotal_Item.TaxAmount = TotalTaxAmount_IGVItem;
                subtotal_Items.Add(subtotal_Item);

                TaxCategoryType taxcategory_IGVItem = new TaxCategoryType();

                IDType idTaxCategoria = new IDType();
                idTaxCategoria.schemeAgencyName = "United Nations Economic Commission for Europe";
                idTaxCategoria.schemeName = "Tax Category Identifier";
                idTaxCategoria.schemeID = "UN/ECE 5305";
                idTaxCategoria.Value = "S";

                PercentType1 porcentaje = new PercentType1();
                porcentaje.Value = Convert.ToDecimal(string.Format("{0:0.##}", 18));
                taxcategory_IGVItem.Percent = porcentaje;
                subtotal_Item.TaxCategory = taxcategory_IGVItem;

                TaxExemptionReasonCodeType ReasonCode = new TaxExemptionReasonCodeType();
                ReasonCode.listAgencyName = "PE:SUNAT";
                ReasonCode.listName = "Afectacion del IGV";
                ReasonCode.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                ReasonCode.Value = "10";
                taxcategory_IGVItem.TaxExemptionReasonCode = ReasonCode;

                TaxSchemeType taxscheme_IGVItem = new TaxSchemeType();
                IDType id2_IGVItem = new IDType();
                id2_IGVItem.schemeName = "Codigo de tributos";
                id2_IGVItem.schemeAgencyName = "PE:SUNAT";
                id2_IGVItem.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo05";
                id2_IGVItem.Value = "1000";
                taxscheme_IGVItem.ID = id2_IGVItem;

                NameType1 nombreImpto_IGVItem = new NameType1();
                nombreImpto_IGVItem.Value = "IGV";
                taxscheme_IGVItem.Name = nombreImpto_IGVItem;

                TaxTypeCodeType nombreImpto_IGVItemInter = new TaxTypeCodeType();
                nombreImpto_IGVItemInter.Value = "VAT";
                taxscheme_IGVItem.TaxTypeCode = nombreImpto_IGVItemInter;

                taxcategory_IGVItem.TaxScheme = taxscheme_IGVItem;

                ////Si encuentra bolsa
                //if (detalle.Codigo.Contains("BBBB"))
                //{
                //    TaxSubtotalType TotalIcb = new TaxSubtotalType();
                //    TaxAmountType taxAmounticb = new TaxAmountType();
                //    taxAmounticb.currencyID = "PEN";
                //    taxAmounticb.Value = Math.Round((detalle.cantidad * detalle.preciounitario), 2);
                //    BaseUnitMeasureType baseicb = new BaseUnitMeasureType();
                //    baseicb.unitCode = detalle.Unidad_de_medida;
                //    baseicb.Value = Convert.ToInt32(detalle.cantidad);
                //    PerUnitAmountType perunicb = new PerUnitAmountType();
                //    perunicb.currencyID = "PEN";
                //    perunicb.Value = detalle.preciounitario;

                //    TotalIcb.TaxAmount = taxAmounticb;
                //    TotalIcb.BaseUnitMeasure = baseicb;

                //    TaxCategoryType categoryicb = new TaxCategoryType();
                //    TaxSchemeType taxicb = new TaxSchemeType();
                //    IDType idtaxcat = new IDType();
                //    idtaxcat.schemeID = "UN/ECE 5305";
                //    idtaxcat.schemeName = "Codigo de tributos";
                //    idtaxcat.schemeAgencyName = "PE:SUNAT";
                //    idtaxcat.Value = "S";
                //    categoryicb.ID = idtaxcat;
                //    categoryicb.PerUnitAmount = perunicb;


                //    IDType idicp = new IDType();
                //    idicp.Value = "7152";
                //    NameType1 nombreicb = new NameType1();
                //    nombreicb.Value = "ICBPER";
                //    TaxTypeCodeType codicb = new TaxTypeCodeType();
                //    codicb.Value = "OTH";

                //    taxicb.ID = idicp;
                //    taxicb.Name = nombreicb;
                //    taxicb.TaxTypeCode = codicb;
                //    categoryicb.TaxScheme = taxicb;
                //    TotalIcb.TaxCategory = categoryicb;
                //    subtotal_Items.Add(TotalIcb);

                //}


                Totales_Item.TaxSubtotal = subtotal_Items.ToArray();
                Totales_Items.Add(Totales_Item);
                item.TaxTotal = Totales_Items.ToArray();


                ItemType itemTipo = new ItemType();
                DescriptionType description = new DescriptionType();
                List<DescriptionType> descriptions = new List<DescriptionType>();
                description.Value = detalle.Descripcion;
                descriptions.Add(description);

                ItemIdentificationType codigoProd = new ItemIdentificationType();
                IDType id = new IDType();
                id.Value = "NTCRD";//detalle.Codigo;
                codigoProd.ID = id;
                itemTipo.Description = descriptions.ToArray();
                itemTipo.SellersItemIdentification = codigoProd;

                List<CommodityClassificationType> codSunats = new List<CommodityClassificationType>();
                CommodityClassificationType codSunat = new CommodityClassificationType();
                ItemClassificationCodeType codClas = new ItemClassificationCodeType();
                codClas.listID = "UNSPSC";
                codClas.listAgencyName = "GS1 US";
                codClas.listName = "Item Classification";
                codClas.Value = "25172405";
                codSunat.ItemClassificationCode = codClas;
                codSunats.Add(codSunat);
                itemTipo.CommodityClassification = codSunats.ToArray();


                PriceType PrecioProducto = new PriceType();
                PriceAmountType PrecioMontoTipo = new PriceAmountType();
                PrecioMontoTipo.currencyID = "PEN";
                decimal porcentajeIgv = Convert.ToDecimal(paramFactura.Porcentaje_IGV / 100);

                PrecioMontoTipo.Value = Convert.ToDecimal(string.Format("{0:0.##}", (detalle.preciounitario - Convert.ToDecimal(detalle.TotalTipoDescuento)) / (1 + porcentajeIgv)));
                PrecioProducto.PriceAmount = PrecioMontoTipo;


                item.Item = itemTipo;
                item.Price = PrecioProducto;
                items.Add(item);
                idtem += 1;
            }
            Factura.CreditNoteLine = items.ToArray();

            #endregion
            string rutaxml = CrearArchivoxmlNotaCredito(Factura, Variables.claseEmpresa.Ruc, /*paramFactura.CodigoComprobante,*/ paramFactura.Serie, paramFactura.Correlativo);
            FirmarXML(rutaxml, Ruta_Certificado, Password_Certificado);
            string rutaenvio = RutaEnvios + Path.GetFileName(rutaxml).Replace(".xml", ".zip");
            //fnConvertiraPdf(rutaxml);
            ComprimirZip(rutaxml, rutaenvio);
            Enviardocumento(rutaenvio);
        }
        private string CrearArchivoxmlNotaCredito(CreditNoteType Nota, string RUCEmisor, string serie, string correlativo)
        {
            //Generar el archivo xml
            XmlWriterSettings propiedades = new XmlWriterSettings();
            propiedades.Indent = true;
            propiedades.IndentChars = "\t";
            string Nombrearchivoxml = RUCEmisor + "-07-" + serie + "-" + correlativo;
            string rutaxml = string.Format(@"{0}{1}.xml", Rutaxml, Nombrearchivoxml);
            using (XmlWriter escribir = XmlWriter.Create(rutaxml, propiedades))
            {
                Type serializacion = typeof(CreditNoteType);
                XmlSerializer crearxml = new XmlSerializer(serializacion);
                crearxml.Serialize(escribir, Nota);
                return rutaxml;
            }
        }
        #endregion

    }
}
