using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfaIntegradoCom
{
    public class SevicioFacturacion
    {
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
        [System.ServiceModel.ServiceContractAttribute(Namespace = "http://service.sunat.gob.pe", ConfigurationName = "SevicioFacturacion.billService")]
        public interface billService
        {

            // CODEGEN: El parámetro 'status' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
            [System.ServiceModel.OperationContractAttribute(Action = "urn:getStatus", ReplyAction = "*")]
            [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
            [return: System.ServiceModel.MessageParameterAttribute(Name = "status")]
            wfaIntegradoCom.SevicioFacturacion.getStatusResponse getStatus(wfaIntegradoCom.SevicioFacturacion.getStatusRequest request);

            [System.ServiceModel.OperationContractAttribute(Action = "urn:getStatus", ReplyAction = "*")]
            System.Threading.Tasks.Task<wfaIntegradoCom.SevicioFacturacion.getStatusResponse> getStatusAsync(wfaIntegradoCom.SevicioFacturacion.getStatusRequest request);

            // CODEGEN: El parámetro 'applicationResponse' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
            [System.ServiceModel.OperationContractAttribute(Action = "urn:sendBill", ReplyAction = "*")]
            [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
            [return: System.ServiceModel.MessageParameterAttribute(Name = "applicationResponse")]
            wfaIntegradoCom.SevicioFacturacion.sendBillResponse sendBill(wfaIntegradoCom.SevicioFacturacion.sendBillRequest request);

            [System.ServiceModel.OperationContractAttribute(Action = "urn:sendBill", ReplyAction = "*")]
            System.Threading.Tasks.Task<wfaIntegradoCom.SevicioFacturacion.sendBillResponse> sendBillAsync(wfaIntegradoCom.SevicioFacturacion.sendBillRequest request);

            // CODEGEN: El parámetro 'ticket' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
            [System.ServiceModel.OperationContractAttribute(Action = "urn:sendPack", ReplyAction = "*")]
            [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
            [return: System.ServiceModel.MessageParameterAttribute(Name = "ticket")]
            wfaIntegradoCom.SevicioFacturacion.sendPackResponse sendPack(wfaIntegradoCom.SevicioFacturacion.sendPackRequest request);

            [System.ServiceModel.OperationContractAttribute(Action = "urn:sendPack", ReplyAction = "*")]
            System.Threading.Tasks.Task<wfaIntegradoCom.SevicioFacturacion.sendPackResponse> sendPackAsync(wfaIntegradoCom.SevicioFacturacion.sendPackRequest request);

            // CODEGEN: El parámetro 'ticket' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
            [System.ServiceModel.OperationContractAttribute(Action = "urn:sendSummary", ReplyAction = "*")]
            [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
            [return: System.ServiceModel.MessageParameterAttribute(Name = "ticket")]
            wfaIntegradoCom.SevicioFacturacion.sendSummaryResponse sendSummary(wfaIntegradoCom.SevicioFacturacion.sendSummaryRequest request);

            [System.ServiceModel.OperationContractAttribute(Action = "urn:sendSummary", ReplyAction = "*")]
            System.Threading.Tasks.Task<wfaIntegradoCom.SevicioFacturacion.sendSummaryResponse> sendSummaryAsync(wfaIntegradoCom.SevicioFacturacion.sendSummaryRequest request);
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.sunat.gob.pe")]
        public partial class statusResponse : object, System.ComponentModel.INotifyPropertyChanged
        {

            private byte[] contentField;

            private string statusCodeField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary", Order = 0)]
            public byte[] content
            {
                get
                {
                    return this.contentField;
                }
                set
                {
                    this.contentField = value;
                    this.RaisePropertyChanged("content");
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
            public string statusCode
            {
                get
                {
                    return this.statusCodeField;
                }
                set
                {
                    this.statusCodeField = value;
                    this.RaisePropertyChanged("statusCode");
                }
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            protected void RaisePropertyChanged(string propertyName)
            {
                System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
                if ((propertyChanged != null))
                {
                    propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
                }
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        [System.ServiceModel.MessageContractAttribute(WrapperName = "getStatus", WrapperNamespace = "http://service.sunat.gob.pe", IsWrapped = true)]
        public partial class getStatusRequest
        {

            [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://service.sunat.gob.pe", Order = 0)]
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string ticket;

            public getStatusRequest()
            {
            }

            public getStatusRequest(string ticket)
            {
                this.ticket = ticket;
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        [System.ServiceModel.MessageContractAttribute(WrapperName = "getStatusResponse", WrapperNamespace = "http://service.sunat.gob.pe", IsWrapped = true)]
        public partial class getStatusResponse
        {

            [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://service.sunat.gob.pe", Order = 0)]
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public wfaIntegradoCom.SevicioFacturacion.statusResponse status;

            public getStatusResponse()
            {
            }

            public getStatusResponse(wfaIntegradoCom.SevicioFacturacion.statusResponse status)
            {
                this.status = status;
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        [System.ServiceModel.MessageContractAttribute(WrapperName = "sendBill", WrapperNamespace = "http://service.sunat.gob.pe", IsWrapped = true)]
        public partial class sendBillRequest
        {

            [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://service.sunat.gob.pe", Order = 0)]
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string fileName;

            [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://service.sunat.gob.pe", Order = 1)]
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] contentFile;

            [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://service.sunat.gob.pe", Order = 2)]
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string partyType;

            public sendBillRequest()
            {
            }

            public sendBillRequest(string fileName, byte[] contentFile, string partyType)
            {
                this.fileName = fileName;
                this.contentFile = contentFile;
                this.partyType = partyType;
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        [System.ServiceModel.MessageContractAttribute(WrapperName = "sendBillResponse", WrapperNamespace = "http://service.sunat.gob.pe", IsWrapped = true)]
        public partial class sendBillResponse
        {

            [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://service.sunat.gob.pe", Order = 0)]
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] applicationResponse;

            public sendBillResponse()
            {
            }

            public sendBillResponse(byte[] applicationResponse)
            {
                this.applicationResponse = applicationResponse;
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        [System.ServiceModel.MessageContractAttribute(WrapperName = "sendPack", WrapperNamespace = "http://service.sunat.gob.pe", IsWrapped = true)]
        public partial class sendPackRequest
        {

            [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://service.sunat.gob.pe", Order = 0)]
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string fileName;

            [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://service.sunat.gob.pe", Order = 1)]
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] contentFile;

            [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://service.sunat.gob.pe", Order = 2)]
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string partyType;

            public sendPackRequest()
            {
            }

            public sendPackRequest(string fileName, byte[] contentFile, string partyType)
            {
                this.fileName = fileName;
                this.contentFile = contentFile;
                this.partyType = partyType;
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        [System.ServiceModel.MessageContractAttribute(WrapperName = "sendPackResponse", WrapperNamespace = "http://service.sunat.gob.pe", IsWrapped = true)]
        public partial class sendPackResponse
        {

            [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://service.sunat.gob.pe", Order = 0)]
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string ticket;

            public sendPackResponse()
            {
            }

            public sendPackResponse(string ticket)
            {
                this.ticket = ticket;
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        [System.ServiceModel.MessageContractAttribute(WrapperName = "sendSummary", WrapperNamespace = "http://service.sunat.gob.pe", IsWrapped = true)]
        public partial class sendSummaryRequest
        {

            [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://service.sunat.gob.pe", Order = 0)]
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string fileName;

            [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://service.sunat.gob.pe", Order = 1)]
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] contentFile;

            [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://service.sunat.gob.pe", Order = 2)]
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string partyType;

            public sendSummaryRequest()
            {
            }

            public sendSummaryRequest(string fileName, byte[] contentFile, string partyType)
            {
                this.fileName = fileName;
                this.contentFile = contentFile;
                this.partyType = partyType;
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        [System.ServiceModel.MessageContractAttribute(WrapperName = "sendSummaryResponse", WrapperNamespace = "http://service.sunat.gob.pe", IsWrapped = true)]
        public partial class sendSummaryResponse
        {

            [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://service.sunat.gob.pe", Order = 0)]
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string ticket;

            public sendSummaryResponse()
            {
            }

            public sendSummaryResponse(string ticket)
            {
                this.ticket = ticket;
            }
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
        public interface billServiceChannel : wfaIntegradoCom.SevicioFacturacion.billService, System.ServiceModel.IClientChannel
        {
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
        public partial class billServiceClient : System.ServiceModel.ClientBase<wfaIntegradoCom.SevicioFacturacion.billService>, wfaIntegradoCom.SevicioFacturacion.billService
        {

            public billServiceClient()
            {
            }

            public billServiceClient(string endpointConfigurationName) :
                    base(endpointConfigurationName)
            {
            }

            public billServiceClient(string endpointConfigurationName, string remoteAddress) :
                    base(endpointConfigurationName, remoteAddress)
            {
            }

            public billServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                    base(endpointConfigurationName, remoteAddress)
            {
            }

            public billServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                    base(binding, remoteAddress)
            {
            }

            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            wfaIntegradoCom.SevicioFacturacion.getStatusResponse wfaIntegradoCom.SevicioFacturacion.billService.getStatus(wfaIntegradoCom.SevicioFacturacion.getStatusRequest request)
            {
                return base.Channel.getStatus(request);
            }

            public wfaIntegradoCom.SevicioFacturacion.statusResponse getStatus(string ticket)
            {
                wfaIntegradoCom.SevicioFacturacion.getStatusRequest inValue = new wfaIntegradoCom.SevicioFacturacion.getStatusRequest();
                inValue.ticket = ticket;
                wfaIntegradoCom.SevicioFacturacion.getStatusResponse retVal = ((wfaIntegradoCom.SevicioFacturacion.billService)(this)).getStatus(inValue);
                return retVal.status;
            }

            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            System.Threading.Tasks.Task<wfaIntegradoCom.SevicioFacturacion.getStatusResponse> wfaIntegradoCom.SevicioFacturacion.billService.getStatusAsync(wfaIntegradoCom.SevicioFacturacion.getStatusRequest request)
            {
                return base.Channel.getStatusAsync(request);
            }

            public System.Threading.Tasks.Task<wfaIntegradoCom.SevicioFacturacion.getStatusResponse> getStatusAsync(string ticket)
            {
                wfaIntegradoCom.SevicioFacturacion.getStatusRequest inValue = new wfaIntegradoCom.SevicioFacturacion.getStatusRequest();
                inValue.ticket = ticket;
                return ((wfaIntegradoCom.SevicioFacturacion.billService)(this)).getStatusAsync(inValue);
            }

            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            wfaIntegradoCom.SevicioFacturacion.sendBillResponse wfaIntegradoCom.SevicioFacturacion.billService.sendBill(wfaIntegradoCom.SevicioFacturacion.sendBillRequest request)
            {
                return base.Channel.sendBill(request);
            }

            public byte[] sendBill(string fileName, byte[] contentFile, string partyType)
            {
                wfaIntegradoCom.SevicioFacturacion.sendBillRequest inValue = new wfaIntegradoCom.SevicioFacturacion.sendBillRequest();
                inValue.fileName = fileName;
                inValue.contentFile = contentFile;
                inValue.partyType = partyType;
                wfaIntegradoCom.SevicioFacturacion.sendBillResponse retVal = ((wfaIntegradoCom.SevicioFacturacion.billService)(this)).sendBill(inValue);
                return retVal.applicationResponse;
            }

            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            System.Threading.Tasks.Task<wfaIntegradoCom.SevicioFacturacion.sendBillResponse> wfaIntegradoCom.SevicioFacturacion.billService.sendBillAsync(wfaIntegradoCom.SevicioFacturacion.sendBillRequest request)
            {
                return base.Channel.sendBillAsync(request);
            }

            public System.Threading.Tasks.Task<wfaIntegradoCom.SevicioFacturacion.sendBillResponse> sendBillAsync(string fileName, byte[] contentFile, string partyType)
            {
                wfaIntegradoCom.SevicioFacturacion.sendBillRequest inValue = new wfaIntegradoCom.SevicioFacturacion.sendBillRequest();
                inValue.fileName = fileName;
                inValue.contentFile = contentFile;
                inValue.partyType = partyType;
                return ((wfaIntegradoCom.SevicioFacturacion.billService)(this)).sendBillAsync(inValue);
            }

            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            wfaIntegradoCom.SevicioFacturacion.sendPackResponse wfaIntegradoCom.SevicioFacturacion.billService.sendPack(wfaIntegradoCom.SevicioFacturacion.sendPackRequest request)
            {
                return base.Channel.sendPack(request);
            }

            public string sendPack(string fileName, byte[] contentFile, string partyType)
            {
                wfaIntegradoCom.SevicioFacturacion.sendPackRequest inValue = new wfaIntegradoCom.SevicioFacturacion.sendPackRequest();
                inValue.fileName = fileName;
                inValue.contentFile = contentFile;
                inValue.partyType = partyType;
                wfaIntegradoCom.SevicioFacturacion.sendPackResponse retVal = ((wfaIntegradoCom.SevicioFacturacion.billService)(this)).sendPack(inValue);
                return retVal.ticket;
            }

            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            System.Threading.Tasks.Task<wfaIntegradoCom.SevicioFacturacion.sendPackResponse> wfaIntegradoCom.SevicioFacturacion.billService.sendPackAsync(wfaIntegradoCom.SevicioFacturacion.sendPackRequest request)
            {
                return base.Channel.sendPackAsync(request);
            }

            public System.Threading.Tasks.Task<wfaIntegradoCom.SevicioFacturacion.sendPackResponse> sendPackAsync(string fileName, byte[] contentFile, string partyType)
            {
                wfaIntegradoCom.SevicioFacturacion.sendPackRequest inValue = new wfaIntegradoCom.SevicioFacturacion.sendPackRequest();
                inValue.fileName = fileName;
                inValue.contentFile = contentFile;
                inValue.partyType = partyType;
                return ((wfaIntegradoCom.SevicioFacturacion.billService)(this)).sendPackAsync(inValue);
            }

            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            wfaIntegradoCom.SevicioFacturacion.sendSummaryResponse wfaIntegradoCom.SevicioFacturacion.billService.sendSummary(wfaIntegradoCom.SevicioFacturacion.sendSummaryRequest request)
            {
                return base.Channel.sendSummary(request);
            }

            public string sendSummary(string fileName, byte[] contentFile, string partyType)
            {
                wfaIntegradoCom.SevicioFacturacion.sendSummaryRequest inValue = new wfaIntegradoCom.SevicioFacturacion.sendSummaryRequest();
                inValue.fileName = fileName;
                inValue.contentFile = contentFile;
                inValue.partyType = partyType;
                wfaIntegradoCom.SevicioFacturacion.sendSummaryResponse retVal = ((wfaIntegradoCom.SevicioFacturacion.billService)(this)).sendSummary(inValue);
                return retVal.ticket;
            }

            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
            System.Threading.Tasks.Task<wfaIntegradoCom.SevicioFacturacion.sendSummaryResponse> wfaIntegradoCom.SevicioFacturacion.billService.sendSummaryAsync(wfaIntegradoCom.SevicioFacturacion.sendSummaryRequest request)
            {
                return base.Channel.sendSummaryAsync(request);
            }

            public System.Threading.Tasks.Task<wfaIntegradoCom.SevicioFacturacion.sendSummaryResponse> sendSummaryAsync(string fileName, byte[] contentFile, string partyType)
            {
                wfaIntegradoCom.SevicioFacturacion.sendSummaryRequest inValue = new wfaIntegradoCom.SevicioFacturacion.sendSummaryRequest();
                inValue.fileName = fileName;
                inValue.contentFile = contentFile;
                inValue.partyType = partyType;
                return ((wfaIntegradoCom.SevicioFacturacion.billService)(this)).sendSummaryAsync(inValue);
            }
        }
    }
}
