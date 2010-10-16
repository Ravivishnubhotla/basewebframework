﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SPSSiteTask.SPDataService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SPSSendUrlEntity", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class SPSSendUrlEntity : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int ClientIDField;
        
        private int ChannelIDField;
        
        private int SycnRetryTimesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SendUrlField;
        
        private int PaymentIDField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int ClientID {
            get {
                return this.ClientIDField;
            }
            set {
                if ((this.ClientIDField.Equals(value) != true)) {
                    this.ClientIDField = value;
                    this.RaisePropertyChanged("ClientID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public int ChannelID {
            get {
                return this.ChannelIDField;
            }
            set {
                if ((this.ChannelIDField.Equals(value) != true)) {
                    this.ChannelIDField = value;
                    this.RaisePropertyChanged("ChannelID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public int SycnRetryTimes {
            get {
                return this.SycnRetryTimesField;
            }
            set {
                if ((this.SycnRetryTimesField.Equals(value) != true)) {
                    this.SycnRetryTimesField = value;
                    this.RaisePropertyChanged("SycnRetryTimes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string SendUrl {
            get {
                return this.SendUrlField;
            }
            set {
                if ((object.ReferenceEquals(this.SendUrlField, value) != true)) {
                    this.SendUrlField = value;
                    this.RaisePropertyChanged("SendUrl");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public int PaymentID {
            get {
                return this.PaymentIDField;
            }
            set {
                if ((this.PaymentIDField.Equals(value) != true)) {
                    this.PaymentIDField = value;
                    this.RaisePropertyChanged("PaymentID");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SPDataService.SPDataServiceSoap")]
    public interface SPDataServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Connect", ReplyAction="*")]
        bool Connect();
        
        // CODEGEN: Generating message contract since element name GetAllClientChannelNeedSendDataResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAllClientChannelNeedSendData", ReplyAction="*")]
        SPSSiteTask.SPDataService.GetAllClientChannelNeedSendDataResponse GetAllClientChannelNeedSendData(SPSSiteTask.SPDataService.GetAllClientChannelNeedSendDataRequest request);
        
        // CODEGEN: Generating message contract since element name GetAllClientChannelNeedSendHistoryDataResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAllClientChannelNeedSendHistoryData", ReplyAction="*")]
        SPSSiteTask.SPDataService.GetAllClientChannelNeedSendHistoryDataResponse GetAllClientChannelNeedSendHistoryData(SPSSiteTask.SPDataService.GetAllClientChannelNeedSendHistoryDataRequest request);
        
        // CODEGEN: Generating message contract since element name sendUrl from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdatePaymentSend", ReplyAction="*")]
        SPSSiteTask.SPDataService.UpdatePaymentSendResponse UpdatePaymentSend(SPSSiteTask.SPDataService.UpdatePaymentSendRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAllClientChannelNeedSendDataRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetAllClientChannelNeedSendData", Namespace="http://tempuri.org/", Order=0)]
        public SPSSiteTask.SPDataService.GetAllClientChannelNeedSendDataRequestBody Body;
        
        public GetAllClientChannelNeedSendDataRequest() {
        }
        
        public GetAllClientChannelNeedSendDataRequest(SPSSiteTask.SPDataService.GetAllClientChannelNeedSendDataRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetAllClientChannelNeedSendDataRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int maxDataCount;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int maxAllDataCount;
        
        public GetAllClientChannelNeedSendDataRequestBody() {
        }
        
        public GetAllClientChannelNeedSendDataRequestBody(int maxDataCount, int maxAllDataCount) {
            this.maxDataCount = maxDataCount;
            this.maxAllDataCount = maxAllDataCount;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAllClientChannelNeedSendDataResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetAllClientChannelNeedSendDataResponse", Namespace="http://tempuri.org/", Order=0)]
        public SPSSiteTask.SPDataService.GetAllClientChannelNeedSendDataResponseBody Body;
        
        public GetAllClientChannelNeedSendDataResponse() {
        }
        
        public GetAllClientChannelNeedSendDataResponse(SPSSiteTask.SPDataService.GetAllClientChannelNeedSendDataResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetAllClientChannelNeedSendDataResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Collections.Generic.List<SPSSiteTask.SPDataService.SPSSendUrlEntity> GetAllClientChannelNeedSendDataResult;
        
        public GetAllClientChannelNeedSendDataResponseBody() {
        }
        
        public GetAllClientChannelNeedSendDataResponseBody(System.Collections.Generic.List<SPSSiteTask.SPDataService.SPSSendUrlEntity> GetAllClientChannelNeedSendDataResult) {
            this.GetAllClientChannelNeedSendDataResult = GetAllClientChannelNeedSendDataResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAllClientChannelNeedSendHistoryDataRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetAllClientChannelNeedSendHistoryData", Namespace="http://tempuri.org/", Order=0)]
        public SPSSiteTask.SPDataService.GetAllClientChannelNeedSendHistoryDataRequestBody Body;
        
        public GetAllClientChannelNeedSendHistoryDataRequest() {
        }
        
        public GetAllClientChannelNeedSendHistoryDataRequest(SPSSiteTask.SPDataService.GetAllClientChannelNeedSendHistoryDataRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetAllClientChannelNeedSendHistoryDataRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int maxDataCount;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int maxAllDataCount;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public System.DateTime startDate;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public System.DateTime endDate;
        
        public GetAllClientChannelNeedSendHistoryDataRequestBody() {
        }
        
        public GetAllClientChannelNeedSendHistoryDataRequestBody(int maxDataCount, int maxAllDataCount, System.DateTime startDate, System.DateTime endDate) {
            this.maxDataCount = maxDataCount;
            this.maxAllDataCount = maxAllDataCount;
            this.startDate = startDate;
            this.endDate = endDate;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAllClientChannelNeedSendHistoryDataResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetAllClientChannelNeedSendHistoryDataResponse", Namespace="http://tempuri.org/", Order=0)]
        public SPSSiteTask.SPDataService.GetAllClientChannelNeedSendHistoryDataResponseBody Body;
        
        public GetAllClientChannelNeedSendHistoryDataResponse() {
        }
        
        public GetAllClientChannelNeedSendHistoryDataResponse(SPSSiteTask.SPDataService.GetAllClientChannelNeedSendHistoryDataResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetAllClientChannelNeedSendHistoryDataResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Collections.Generic.List<SPSSiteTask.SPDataService.SPSSendUrlEntity> GetAllClientChannelNeedSendHistoryDataResult;
        
        public GetAllClientChannelNeedSendHistoryDataResponseBody() {
        }
        
        public GetAllClientChannelNeedSendHistoryDataResponseBody(System.Collections.Generic.List<SPSSiteTask.SPDataService.SPSSendUrlEntity> GetAllClientChannelNeedSendHistoryDataResult) {
            this.GetAllClientChannelNeedSendHistoryDataResult = GetAllClientChannelNeedSendHistoryDataResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdatePaymentSendRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UpdatePaymentSend", Namespace="http://tempuri.org/", Order=0)]
        public SPSSiteTask.SPDataService.UpdatePaymentSendRequestBody Body;
        
        public UpdatePaymentSendRequest() {
        }
        
        public UpdatePaymentSendRequest(SPSSiteTask.SPDataService.UpdatePaymentSendRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class UpdatePaymentSendRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int id;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public bool isSendOk;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string sendUrl;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public int sycnRetryTimes;
        
        public UpdatePaymentSendRequestBody() {
        }
        
        public UpdatePaymentSendRequestBody(int id, bool isSendOk, string sendUrl, int sycnRetryTimes) {
            this.id = id;
            this.isSendOk = isSendOk;
            this.sendUrl = sendUrl;
            this.sycnRetryTimes = sycnRetryTimes;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdatePaymentSendResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UpdatePaymentSendResponse", Namespace="http://tempuri.org/", Order=0)]
        public SPSSiteTask.SPDataService.UpdatePaymentSendResponseBody Body;
        
        public UpdatePaymentSendResponse() {
        }
        
        public UpdatePaymentSendResponse(SPSSiteTask.SPDataService.UpdatePaymentSendResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class UpdatePaymentSendResponseBody {
        
        public UpdatePaymentSendResponseBody() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SPDataServiceSoapChannel : SPSSiteTask.SPDataService.SPDataServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SPDataServiceSoapClient : System.ServiceModel.ClientBase<SPSSiteTask.SPDataService.SPDataServiceSoap>, SPSSiteTask.SPDataService.SPDataServiceSoap {
        
        public SPDataServiceSoapClient() {
        }
        
        public SPDataServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SPDataServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SPDataServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SPDataServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Connect() {
            return base.Channel.Connect();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SPSSiteTask.SPDataService.GetAllClientChannelNeedSendDataResponse SPSSiteTask.SPDataService.SPDataServiceSoap.GetAllClientChannelNeedSendData(SPSSiteTask.SPDataService.GetAllClientChannelNeedSendDataRequest request) {
            return base.Channel.GetAllClientChannelNeedSendData(request);
        }
        
        public System.Collections.Generic.List<SPSSiteTask.SPDataService.SPSSendUrlEntity> GetAllClientChannelNeedSendData(int maxDataCount, int maxAllDataCount) {
            SPSSiteTask.SPDataService.GetAllClientChannelNeedSendDataRequest inValue = new SPSSiteTask.SPDataService.GetAllClientChannelNeedSendDataRequest();
            inValue.Body = new SPSSiteTask.SPDataService.GetAllClientChannelNeedSendDataRequestBody();
            inValue.Body.maxDataCount = maxDataCount;
            inValue.Body.maxAllDataCount = maxAllDataCount;
            SPSSiteTask.SPDataService.GetAllClientChannelNeedSendDataResponse retVal = ((SPSSiteTask.SPDataService.SPDataServiceSoap)(this)).GetAllClientChannelNeedSendData(inValue);
            return retVal.Body.GetAllClientChannelNeedSendDataResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SPSSiteTask.SPDataService.GetAllClientChannelNeedSendHistoryDataResponse SPSSiteTask.SPDataService.SPDataServiceSoap.GetAllClientChannelNeedSendHistoryData(SPSSiteTask.SPDataService.GetAllClientChannelNeedSendHistoryDataRequest request) {
            return base.Channel.GetAllClientChannelNeedSendHistoryData(request);
        }
        
        public System.Collections.Generic.List<SPSSiteTask.SPDataService.SPSSendUrlEntity> GetAllClientChannelNeedSendHistoryData(int maxDataCount, int maxAllDataCount, System.DateTime startDate, System.DateTime endDate) {
            SPSSiteTask.SPDataService.GetAllClientChannelNeedSendHistoryDataRequest inValue = new SPSSiteTask.SPDataService.GetAllClientChannelNeedSendHistoryDataRequest();
            inValue.Body = new SPSSiteTask.SPDataService.GetAllClientChannelNeedSendHistoryDataRequestBody();
            inValue.Body.maxDataCount = maxDataCount;
            inValue.Body.maxAllDataCount = maxAllDataCount;
            inValue.Body.startDate = startDate;
            inValue.Body.endDate = endDate;
            SPSSiteTask.SPDataService.GetAllClientChannelNeedSendHistoryDataResponse retVal = ((SPSSiteTask.SPDataService.SPDataServiceSoap)(this)).GetAllClientChannelNeedSendHistoryData(inValue);
            return retVal.Body.GetAllClientChannelNeedSendHistoryDataResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SPSSiteTask.SPDataService.UpdatePaymentSendResponse SPSSiteTask.SPDataService.SPDataServiceSoap.UpdatePaymentSend(SPSSiteTask.SPDataService.UpdatePaymentSendRequest request) {
            return base.Channel.UpdatePaymentSend(request);
        }
        
        public void UpdatePaymentSend(int id, bool isSendOk, string sendUrl, int sycnRetryTimes) {
            SPSSiteTask.SPDataService.UpdatePaymentSendRequest inValue = new SPSSiteTask.SPDataService.UpdatePaymentSendRequest();
            inValue.Body = new SPSSiteTask.SPDataService.UpdatePaymentSendRequestBody();
            inValue.Body.id = id;
            inValue.Body.isSendOk = isSendOk;
            inValue.Body.sendUrl = sendUrl;
            inValue.Body.sycnRetryTimes = sycnRetryTimes;
            SPSSiteTask.SPDataService.UpdatePaymentSendResponse retVal = ((SPSSiteTask.SPDataService.SPDataServiceSoap)(this)).UpdatePaymentSend(inValue);
        }
    }
}
