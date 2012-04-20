﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 5.0.61118.0
// 
namespace SLHotSpot.HotSpotService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="HotSpotService.HotSpotWebServiceSoap")]
    public interface HotSpotWebServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/SaveHotspotData", ReplyAction="*")]
        System.IAsyncResult BeginSaveHotspotData(SLHotSpot.HotSpotService.SaveHotspotDataRequest request, System.AsyncCallback callback, object asyncState);
        
        SLHotSpot.HotSpotService.SaveHotspotDataResponse EndSaveHotspotData(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/LoadHotspotData", ReplyAction="*")]
        System.IAsyncResult BeginLoadHotspotData(SLHotSpot.HotSpotService.LoadHotspotDataRequest request, System.AsyncCallback callback, object asyncState);
        
        SLHotSpot.HotSpotService.LoadHotspotDataResponse EndLoadHotspotData(System.IAsyncResult result);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SaveHotspotDataRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SaveHotspotData", Namespace="http://tempuri.org/", Order=0)]
        public SLHotSpot.HotSpotService.SaveHotspotDataRequestBody Body;
        
        public SaveHotspotDataRequest() {
        }
        
        public SaveHotspotDataRequest(SLHotSpot.HotSpotService.SaveHotspotDataRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class SaveHotspotDataRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string shopNo;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string hotSpotData;
        
        public SaveHotspotDataRequestBody() {
        }
        
        public SaveHotspotDataRequestBody(string shopNo, string hotSpotData) {
            this.shopNo = shopNo;
            this.hotSpotData = hotSpotData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SaveHotspotDataResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SaveHotspotDataResponse", Namespace="http://tempuri.org/", Order=0)]
        public SLHotSpot.HotSpotService.SaveHotspotDataResponseBody Body;
        
        public SaveHotspotDataResponse() {
        }
        
        public SaveHotspotDataResponse(SLHotSpot.HotSpotService.SaveHotspotDataResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class SaveHotspotDataResponseBody {
        
        public SaveHotspotDataResponseBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class LoadHotspotDataRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="LoadHotspotData", Namespace="http://tempuri.org/", Order=0)]
        public SLHotSpot.HotSpotService.LoadHotspotDataRequestBody Body;
        
        public LoadHotspotDataRequest() {
        }
        
        public LoadHotspotDataRequest(SLHotSpot.HotSpotService.LoadHotspotDataRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class LoadHotspotDataRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string shopNo;
        
        public LoadHotspotDataRequestBody() {
        }
        
        public LoadHotspotDataRequestBody(string shopNo) {
            this.shopNo = shopNo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class LoadHotspotDataResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="LoadHotspotDataResponse", Namespace="http://tempuri.org/", Order=0)]
        public SLHotSpot.HotSpotService.LoadHotspotDataResponseBody Body;
        
        public LoadHotspotDataResponse() {
        }
        
        public LoadHotspotDataResponse(SLHotSpot.HotSpotService.LoadHotspotDataResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class LoadHotspotDataResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string LoadHotspotDataResult;
        
        public LoadHotspotDataResponseBody() {
        }
        
        public LoadHotspotDataResponseBody(string LoadHotspotDataResult) {
            this.LoadHotspotDataResult = LoadHotspotDataResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface HotSpotWebServiceSoapChannel : SLHotSpot.HotSpotService.HotSpotWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LoadHotspotDataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public LoadHotspotDataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HotSpotWebServiceSoapClient : System.ServiceModel.ClientBase<SLHotSpot.HotSpotService.HotSpotWebServiceSoap>, SLHotSpot.HotSpotService.HotSpotWebServiceSoap {
        
        private BeginOperationDelegate onBeginSaveHotspotDataDelegate;
        
        private EndOperationDelegate onEndSaveHotspotDataDelegate;
        
        private System.Threading.SendOrPostCallback onSaveHotspotDataCompletedDelegate;
        
        private BeginOperationDelegate onBeginLoadHotspotDataDelegate;
        
        private EndOperationDelegate onEndLoadHotspotDataDelegate;
        
        private System.Threading.SendOrPostCallback onLoadHotspotDataCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public HotSpotWebServiceSoapClient() {
        }
        
        public HotSpotWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HotSpotWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HotSpotWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HotSpotWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> SaveHotspotDataCompleted;
        
        public event System.EventHandler<LoadHotspotDataCompletedEventArgs> LoadHotspotDataCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult SLHotSpot.HotSpotService.HotSpotWebServiceSoap.BeginSaveHotspotData(SLHotSpot.HotSpotService.SaveHotspotDataRequest request, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSaveHotspotData(request, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private System.IAsyncResult BeginSaveHotspotData(string shopNo, string hotSpotData, System.AsyncCallback callback, object asyncState) {
            SLHotSpot.HotSpotService.SaveHotspotDataRequest inValue = new SLHotSpot.HotSpotService.SaveHotspotDataRequest();
            inValue.Body = new SLHotSpot.HotSpotService.SaveHotspotDataRequestBody();
            inValue.Body.shopNo = shopNo;
            inValue.Body.hotSpotData = hotSpotData;
            return ((SLHotSpot.HotSpotService.HotSpotWebServiceSoap)(this)).BeginSaveHotspotData(inValue, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SLHotSpot.HotSpotService.SaveHotspotDataResponse SLHotSpot.HotSpotService.HotSpotWebServiceSoap.EndSaveHotspotData(System.IAsyncResult result) {
            return base.Channel.EndSaveHotspotData(result);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private void EndSaveHotspotData(System.IAsyncResult result) {
            SLHotSpot.HotSpotService.SaveHotspotDataResponse retVal = ((SLHotSpot.HotSpotService.HotSpotWebServiceSoap)(this)).EndSaveHotspotData(result);
        }
        
        private System.IAsyncResult OnBeginSaveHotspotData(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string shopNo = ((string)(inValues[0]));
            string hotSpotData = ((string)(inValues[1]));
            return this.BeginSaveHotspotData(shopNo, hotSpotData, callback, asyncState);
        }
        
        private object[] OnEndSaveHotspotData(System.IAsyncResult result) {
            this.EndSaveHotspotData(result);
            return null;
        }
        
        private void OnSaveHotspotDataCompleted(object state) {
            if ((this.SaveHotspotDataCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SaveHotspotDataCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SaveHotspotDataAsync(string shopNo, string hotSpotData) {
            this.SaveHotspotDataAsync(shopNo, hotSpotData, null);
        }
        
        public void SaveHotspotDataAsync(string shopNo, string hotSpotData, object userState) {
            if ((this.onBeginSaveHotspotDataDelegate == null)) {
                this.onBeginSaveHotspotDataDelegate = new BeginOperationDelegate(this.OnBeginSaveHotspotData);
            }
            if ((this.onEndSaveHotspotDataDelegate == null)) {
                this.onEndSaveHotspotDataDelegate = new EndOperationDelegate(this.OnEndSaveHotspotData);
            }
            if ((this.onSaveHotspotDataCompletedDelegate == null)) {
                this.onSaveHotspotDataCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSaveHotspotDataCompleted);
            }
            base.InvokeAsync(this.onBeginSaveHotspotDataDelegate, new object[] {
                        shopNo,
                        hotSpotData}, this.onEndSaveHotspotDataDelegate, this.onSaveHotspotDataCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult SLHotSpot.HotSpotService.HotSpotWebServiceSoap.BeginLoadHotspotData(SLHotSpot.HotSpotService.LoadHotspotDataRequest request, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginLoadHotspotData(request, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private System.IAsyncResult BeginLoadHotspotData(string shopNo, System.AsyncCallback callback, object asyncState) {
            SLHotSpot.HotSpotService.LoadHotspotDataRequest inValue = new SLHotSpot.HotSpotService.LoadHotspotDataRequest();
            inValue.Body = new SLHotSpot.HotSpotService.LoadHotspotDataRequestBody();
            inValue.Body.shopNo = shopNo;
            return ((SLHotSpot.HotSpotService.HotSpotWebServiceSoap)(this)).BeginLoadHotspotData(inValue, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SLHotSpot.HotSpotService.LoadHotspotDataResponse SLHotSpot.HotSpotService.HotSpotWebServiceSoap.EndLoadHotspotData(System.IAsyncResult result) {
            return base.Channel.EndLoadHotspotData(result);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private string EndLoadHotspotData(System.IAsyncResult result) {
            SLHotSpot.HotSpotService.LoadHotspotDataResponse retVal = ((SLHotSpot.HotSpotService.HotSpotWebServiceSoap)(this)).EndLoadHotspotData(result);
            return retVal.Body.LoadHotspotDataResult;
        }
        
        private System.IAsyncResult OnBeginLoadHotspotData(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string shopNo = ((string)(inValues[0]));
            return this.BeginLoadHotspotData(shopNo, callback, asyncState);
        }
        
        private object[] OnEndLoadHotspotData(System.IAsyncResult result) {
            string retVal = this.EndLoadHotspotData(result);
            return new object[] {
                    retVal};
        }
        
        private void OnLoadHotspotDataCompleted(object state) {
            if ((this.LoadHotspotDataCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.LoadHotspotDataCompleted(this, new LoadHotspotDataCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void LoadHotspotDataAsync(string shopNo) {
            this.LoadHotspotDataAsync(shopNo, null);
        }
        
        public void LoadHotspotDataAsync(string shopNo, object userState) {
            if ((this.onBeginLoadHotspotDataDelegate == null)) {
                this.onBeginLoadHotspotDataDelegate = new BeginOperationDelegate(this.OnBeginLoadHotspotData);
            }
            if ((this.onEndLoadHotspotDataDelegate == null)) {
                this.onEndLoadHotspotDataDelegate = new EndOperationDelegate(this.OnEndLoadHotspotData);
            }
            if ((this.onLoadHotspotDataCompletedDelegate == null)) {
                this.onLoadHotspotDataCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnLoadHotspotDataCompleted);
            }
            base.InvokeAsync(this.onBeginLoadHotspotDataDelegate, new object[] {
                        shopNo}, this.onEndLoadHotspotDataDelegate, this.onLoadHotspotDataCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override SLHotSpot.HotSpotService.HotSpotWebServiceSoap CreateChannel() {
            return new HotSpotWebServiceSoapClientChannel(this);
        }
        
        private class HotSpotWebServiceSoapClientChannel : ChannelBase<SLHotSpot.HotSpotService.HotSpotWebServiceSoap>, SLHotSpot.HotSpotService.HotSpotWebServiceSoap {
            
            public HotSpotWebServiceSoapClientChannel(System.ServiceModel.ClientBase<SLHotSpot.HotSpotService.HotSpotWebServiceSoap> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginSaveHotspotData(SLHotSpot.HotSpotService.SaveHotspotDataRequest request, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = request;
                System.IAsyncResult _result = base.BeginInvoke("SaveHotspotData", _args, callback, asyncState);
                return _result;
            }
            
            public SLHotSpot.HotSpotService.SaveHotspotDataResponse EndSaveHotspotData(System.IAsyncResult result) {
                object[] _args = new object[0];
                SLHotSpot.HotSpotService.SaveHotspotDataResponse _result = ((SLHotSpot.HotSpotService.SaveHotspotDataResponse)(base.EndInvoke("SaveHotspotData", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginLoadHotspotData(SLHotSpot.HotSpotService.LoadHotspotDataRequest request, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = request;
                System.IAsyncResult _result = base.BeginInvoke("LoadHotspotData", _args, callback, asyncState);
                return _result;
            }
            
            public SLHotSpot.HotSpotService.LoadHotspotDataResponse EndLoadHotspotData(System.IAsyncResult result) {
                object[] _args = new object[0];
                SLHotSpot.HotSpotService.LoadHotspotDataResponse _result = ((SLHotSpot.HotSpotService.LoadHotspotDataResponse)(base.EndInvoke("LoadHotspotData", _args, result)));
                return _result;
            }
        }
    }
}
