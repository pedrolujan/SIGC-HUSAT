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

        public void GenerarFacturaXML(ParametrosFactura paramFactura,Cliente clsCliente,List<DetalleVenta> lstDetalleVentas)
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
            Factura.DueDate = new DueDateType();
            string fechavencimiento = Convert.ToDateTime(paramFactura.Fecha_de_pago).ToString("yyyy-MM-dd");
            Factura.DueDate.Value = Convert.ToDateTime(fechavencimiento);

            //Tipo de factura
            InvoiceTypeCodeType TipoFactura = new InvoiceTypeCodeType();
            TipoFactura.listID = "0101";//Factura  de venta interna
            TipoFactura.listAgencyName = "PE:SUNAT";
            TipoFactura.listName = "Tipo de Documento";
            TipoFactura.name = "Tipo de Operacion";
            TipoFactura.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01";
            TipoFactura.listSchemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo51";
            TipoFactura.Value = paramFactura.CodigoComprobante;
            Factura.InvoiceTypeCode = TipoFactura;

            //Leyenda del comprobante
            NoteType Leyenda = new NoteType();
            Leyenda.languageLocaleID = "1000";
            Leyenda.Value = "MONTO EN SOLES";
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
            idFirma.Value = Variables.claseEmpresa.Ruc;
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
            registronombre.Value = Variables.claseEmpresa.Ruc;
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
            idtipoCliente.schemeID = "6";
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
            taxAmountImpto.Value = Convert.ToDecimal(string.Format("{0:0.00}", paramFactura.TotalIgv));
            TotalImptos.TaxAmount = taxAmountImpto;
            ////</cbc:TaxAmount>

            ////<cac:TaxSubtotal>
            List<TaxSubtotalType> subtotales = new List<TaxSubtotalType>();
            TaxSubtotalType subtotal = new TaxSubtotalType();

            //////<cbc:TaxableAmount
            TaxableAmountType taxsubtotal = new TaxableAmountType();
            taxsubtotal.currencyID = "PEN";
            taxsubtotal.Value = Convert.ToDecimal(string.Format("{0:0.00}", paramFactura.TotSubtotal));
            subtotal.TaxableAmount = taxsubtotal;
            //////</cbc:TaxableAmount>

            //////<cbc:TaxAmount
            TaxAmountType TotalTaxAmountTotal = new TaxAmountType();
            TotalTaxAmountTotal.currencyID = "PEN";
            TotalTaxAmountTotal.Value = Convert.ToDecimal(string.Format("{0:0.00}", paramFactura.TotalIgv));
            subtotal.TaxAmount = TotalTaxAmountTotal;
            //subtotales.Add(subtotal);
            //TotalImptos.TaxSubtotal = subtotales.ToArray();
            //////</cbc:TaxAmount>

            //////<cac:TaxCategory>
            TaxCategoryType taxcategoryTotal = new TaxCategoryType();
            ////////<cac:TaxScheme>
            TaxSchemeType taxScheme = new TaxSchemeType();
            //////////<cbc:ID
            IDType idtotal = new IDType();
            idtotal.schemeName = "Codigo de tributos";
            idtotal.schemeAgencyName = "PE:SUNAT";
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
            //</cac:TaxTotal>
            #endregion
            #region <cac:LegalMonetaryTotal> TOTALES
            MonetaryTotalType TotalValorVenta = new MonetaryTotalType();
            LineExtensionAmountType lineExtensionAmount = new LineExtensionAmountType();
            lineExtensionAmount.currencyID = "PEN";
            lineExtensionAmount.Value = Convert.ToDecimal(string.Format("{0:0.00}", paramFactura.TotSubtotal));
            TotalValorVenta.LineExtensionAmount = lineExtensionAmount;

            TaxInclusiveAmountType taxInclusiveAmount = new TaxInclusiveAmountType();
            taxInclusiveAmount.currencyID = "PEN";
            taxInclusiveAmount.Value = Convert.ToDecimal(string.Format("{0:0.00}", paramFactura.Monto_total));
            TotalValorVenta.TaxInclusiveAmount = taxInclusiveAmount;

            AllowanceTotalAmountType allowanceTotalAmount = new AllowanceTotalAmountType();
            allowanceTotalAmount.currencyID = "PEN";
            allowanceTotalAmount.Value = 0.00m;
            TotalValorVenta.AllowanceTotalAmount = allowanceTotalAmount;

            PrepaidAmountType prepaidAmount = new PrepaidAmountType();
            prepaidAmount.currencyID = "PEN";
            prepaidAmount.Value = 0.00m;
            TotalValorVenta.PrepaidAmount = prepaidAmount;

            ChargeTotalAmountType chargeTotalAmount = new ChargeTotalAmountType();
            chargeTotalAmount.currencyID = "PEN";
            chargeTotalAmount.Value = 0.00m;
            TotalValorVenta.ChargeTotalAmount = chargeTotalAmount;



            PayableAmountType payableAmount = new PayableAmountType();
            payableAmount.currencyID = "PEN";
            payableAmount.Value = Convert.ToDecimal(string.Format("{0:0.00}", paramFactura.Monto_total));
            TotalValorVenta.PayableAmount = payableAmount;
            Factura.LegalMonetaryTotal = TotalValorVenta;

            #endregion
            #region <cac:InvoiceLine> PRODUCTOS DE LA FACTURA
            List<InvoiceLineType> items = new List<InvoiceLineType>();
            int idtem = 1;
            foreach (DetalleVenta detalle in lstDetalleVentas)
            {
                InvoiceLineType item = new InvoiceLineType();
                IDType numeroItem = new IDType();
                numeroItem.Value = idtem.ToString();
                item.ID = numeroItem;

                InvoicedQuantityType cantidad = new InvoicedQuantityType();
                cantidad.unitCode = detalle.Unidad_de_medida;
                cantidad.unitCodeListID = "UN/ECE rec 20";
                cantidad.unitCodeListAgencyName = "United Nations Economic Commission for Europe";
                cantidad.Value = detalle.Cantidad;
                item.InvoicedQuantity = cantidad;

                LineExtensionAmountType ValorVenta = new LineExtensionAmountType();
                ValorVenta.currencyID = "PEN";
                ValorVenta.Value = Convert.ToDecimal(string.Format("{0:0.00}", lstDetalleVentas.Sum(i=>i.preciounitario)  / (1 + 0.18m)));
                item.LineExtensionAmount = ValorVenta;

                PricingReferenceType ValorReferenUnitario = new PricingReferenceType();

                List<PriceType> TipoPrecios = new List<PriceType>();
                PriceType TipoPrecio = new PriceType();
                PriceAmountType PrecioMonto = new PriceAmountType();
                PrecioMonto.currencyID = "PEN";
                PrecioMonto.Value = Convert.ToDecimal(string.Format("{0:0.00}", detalle.preciounitario));
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

                Decimal dcSubtotal = detalle.mtoValorVentaItem / (1.18m);

                List<TaxTotalType> Totales_Items = new List<TaxTotalType>();
                TaxTotalType Totales_Item = new TaxTotalType();
                TaxAmountType Total_Item = new TaxAmountType();
                Total_Item.currencyID = "PEN";
                Total_Item.Value = Convert.ToDecimal(string.Format("{0:0.00}", dcSubtotal * (0.18m)));
                Totales_Item.TaxAmount = Total_Item;

                List<TaxSubtotalType> subtotal_Items = new List<TaxSubtotalType>();
                TaxSubtotalType subtotal_Item = new TaxSubtotalType();
                TaxableAmountType taxsubtotal_IGVItem = new TaxableAmountType();
                taxsubtotal_IGVItem.currencyID = "PEN";
                taxsubtotal_IGVItem.Value = Convert.ToDecimal(string.Format("{0:0.00}", dcSubtotal));
                subtotal_Item.TaxableAmount = taxsubtotal_IGVItem;

                TaxAmountType TotalTaxAmount_IGVItem = new TaxAmountType();
                TotalTaxAmount_IGVItem.currencyID = "PEN";
                TotalTaxAmount_IGVItem.Value = Convert.ToDecimal(string.Format("{0:0.00}", dcSubtotal * (0.18m)));
                subtotal_Item.TaxAmount = TotalTaxAmount_IGVItem;
                subtotal_Items.Add(subtotal_Item);

                TaxCategoryType taxcategory_IGVItem = new TaxCategoryType();
                PercentType1 porcentaje = new PercentType1();
                porcentaje.Value = Convert.ToDecimal(string.Format("{0:0.00}", 18));
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
                id.Value = "HSTCOD";//detalle.Codigo;
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

                PrecioMontoTipo.Value = Convert.ToDecimal(string.Format("{0:0.00}", detalle.preciounitario / (1 + porcentajeIgv)));
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
            Enviardocumento(rutaenvio);
        }

        private void fnConvertiraPdf(String rutaxml)
        {
            // Path to the XML file
            string xmlPath = rutaxml;

            // Path to the output PDF file
            string pdfPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\CDR\factura.pdf";

            // Read the XML file
            string xmlContent = File.ReadAllText(xmlPath);

            // Create a new PDF document
            Document pdfDocument = new Document(PageSize.A4);

            // Set the margins
            pdfDocument.SetMargins(36, 36, 36, 36);

            // Create a new PDF writer
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDocument, new FileStream(pdfPath, FileMode.Create));

            // Open the PDF document
            pdfDocument.Open();

            // Parse the XML content to HTML
            var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(xmlContent), null);

            // Add the parsed HTML elements to the PDF document
            foreach (var htmlElement in parsedHtmlElements)
            {
                pdfDocument.Add(htmlElement);
            }

            // Close the PDF document
            pdfDocument.Close();
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

        private void fnFirmar(string cRutaArchivo, string cCertificado, string cClave)
        {
            //X509Certificate2 cert = new X509Certificate2("certificado.pfx", "password");
            //SignedXml signedXml = new SignedXml(xmlDocument);
            //Reference reference = new Reference();
            //reference.Uri = "";
            //XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            //reference.AddTransform(env);
            //signedXml.AddReference(reference);
            //RSACryptoServiceProvider rsaKey = (RSACryptoServiceProvider)cert.PrivateKey;
            //signedXml.SigningKey = rsaKey;
            //KeyInfo keyInfo = new KeyInfo();
            //keyInfo.AddClause(new KeyInfoX509Data(cert));
            //signedXml.KeyInfo = keyInfo;

            //signedXml.ComputeSignature();

            //XmlElement xmlDigitalSignature = signedXml.GetXml();
            //xmlDocument.DocumentElement.AppendChild(xmlDocument.ImportNode(xmlDigitalSignature, true));






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
                    case "03" // factura y boleta
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
        public void Enviardocumento(string Archivo)
        {
            string filezip = Archivo;
            string filepath = filezip;
            byte[] bitArray = File.ReadAllBytes(filepath);
            try
            {
                //WSHttpBinding binding = new WSHttpBinding();
                //ChannelFactory<ICalculator> factory = new
                //                    ChannelFactory<ICalculator>(binding, address);
                //ICalculator channel = factory.CreateChannel();

                BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;
                binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                binding.Security.Message.AlgorithmSuite = System.ServiceModel.Security.SecurityAlgorithmSuite.Default;

                EndpointAddress remoteAddress = new EndpointAddress("https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService");
                billServiceClient servicio = new billServiceClient(binding, remoteAddress);
                ServicePointManager.UseNagleAlgorithm = true;
                ServicePointManager.Expect100Continue = false;
                ServicePointManager.CheckCertificateRevocationList = true;
                servicio.ClientCredentials.UserName.UserName = "20602404863MODDATOS";
                //servicio.ClientCredentials.UserName.UserName = "20602404863facturas";
                //servicio.ClientCredentials.UserName.Password = "Mihusat1";
                servicio.ClientCredentials.UserName.Password = "MODDATOS";

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
                MessageBox.Show("Archivo generado con exito");

                var respuesta = new EmitirFactura();
                respuesta.ObtenerRespuestaZIPSunat(RutaCDR + "R-" + filezip);
            }
            catch (FaultException ex)
            {
                MessageBox.Show(ex.Code.Name);
            }

        }

        public void  ObtenerQr()
        {
            String Ruc = "20602404863";
            String TipoFactura = "01";
            String Serie = "E001";
            String Correlativo = "517";
            String igv = "57.97";
            String importTotal = "380.00";
            String fecha = "2023-02-09";
            String codTipoDocResceptor = "6";
            String RucReceptor = "20600039491";
            String firmaDigital = "8YTJ4EeWCLkgfsNqD4eS+QRZoOM=";

            string digestValue = Ruc+"|"+TipoFactura + "|"+Serie + "|"+Correlativo + "|"+igv + "|"+importTotal + "|"+fecha+"|"+ codTipoDocResceptor + "|"+RucReceptor + "|"+ firmaDigital+"|";
            //20508565934 | 01 | F959 | 00004735 | 5.32 | 34.90 | 2019 - 07 - 06 | 6 | 20602404863 | VTdFMperZARjUGmcsne5Tlmx0NI =|
            Bitmap bitmap = GenerarQR(digestValue);
            bitmap.Save("QRCode2ok_Hoy.png");
        }
        private static string GetPrivateKey()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.FromXmlString(@"<RSAKeyValue><Modulus>y0...</Modulus><Exponent>AQAB</Exponent><P>/...</P><Q>z...</Q><DP>x...</DP><DQ>w...</DQ><InverseQ>v...</InverseQ><D>u...</D></RSAKeyValue>");
                return rsa.ToXmlString(true);
            }
        }
        static Bitmap GenerarQR(string texto)
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = 300,
                    Width = 300
                }
            };
            return writer.Write(texto);
        }
    }
}
