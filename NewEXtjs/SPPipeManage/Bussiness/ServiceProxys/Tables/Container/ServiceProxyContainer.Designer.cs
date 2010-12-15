using System;
using System.Collections.Generic;
using System.Text;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;



namespace LD.SPPipeManage.Bussiness.ServiceProxys.Tables.Container{
    public partial class ServiceProxyContainer
    {		
		public ISPChannelServiceProxy SPChannelServiceProxyInstance
        {get; set;}
		public ISPChannelDefaultClientSycnParamsServiceProxy SPChannelDefaultClientSycnParamsServiceProxyInstance
        {get; set;}
		public ISPChannelFiltersServiceProxy SPChannelFiltersServiceProxyInstance
        {get; set;}
		public ISPChannelParamsServiceProxy SPChannelParamsServiceProxyInstance
        {get; set;}
		public ISPClientServiceProxy SPClientServiceProxyInstance
        {get; set;}
		public ISPClientChannelSettingServiceProxy SPClientChannelSettingServiceProxyInstance
        {get; set;}
		public ISPClientChannelSettingFiltersServiceProxy SPClientChannelSettingFiltersServiceProxyInstance
        {get; set;}
		public ISPClientChannelSycnParamsServiceProxy SPClientChannelSycnParamsServiceProxyInstance
        {get; set;}
		public ISPClientGroupServiceProxy SPClientGroupServiceProxyInstance
        {get; set;}
		public ISPClientPriceServiceProxy SPClientPriceServiceProxyInstance
        {get; set;}
		public ISPDayReportServiceProxy SPDayReportServiceProxyInstance
        {get; set;}
		public ISPFailedRequestServiceProxy SPFailedRequestServiceProxyInstance
        {get; set;}
		public ISPInterceptRateServiceProxy SPInterceptRateServiceProxyInstance
        {get; set;}
		public ISPMemoServiceProxy SPMemoServiceProxyInstance
        {get; set;}
		public ISPMonitoringRequestServiceProxy SPMonitoringRequestServiceProxyInstance
        {get; set;}
		public ISPPaymentInfoServiceProxy SPPaymentInfoServiceProxyInstance
        {get; set;}
		public ISPPhoneAreaServiceProxy SPPhoneAreaServiceProxyInstance
        {get; set;}
		public ISPRequestInfoServiceProxy SPRequestInfoServiceProxyInstance
        {get; set;}
		public ISPSendClientParamsServiceProxy SPSendClientParamsServiceProxyInstance
        {get; set;}
		public ISPSendRequestInfoServiceProxy SPSendRequestInfoServiceProxyInstance
        {get; set;}
		public ISPSStatePaymentInfoServiceProxy SPSStatePaymentInfoServiceProxyInstance
        {get; set;}
		public ISPStatReportServiceProxy SPStatReportServiceProxyInstance
        {get; set;}
		public ISPTestRecievedServiceProxy SPTestRecievedServiceProxyInstance
        {get; set;}
		public ISPUperServiceProxy SPUperServiceProxyInstance
        {get; set;}




	}
}
