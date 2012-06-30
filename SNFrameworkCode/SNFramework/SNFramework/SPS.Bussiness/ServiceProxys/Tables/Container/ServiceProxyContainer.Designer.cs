using System;
using System.Collections.Generic;
using System.Text;
using SPS.Bussiness.ServiceProxys.Tables;



namespace SPS.Bussiness.ServiceProxys.Tables.Container{
    public partial class ServiceProxyContainer
    {		
		public ISPChannelServiceProxy SPChannelServiceProxyInstance
        {get; set;}
		public ISPChannelParamsServiceProxy SPChannelParamsServiceProxyInstance
        {get; set;}
		public ISPChannelSycnParamsServiceProxy SPChannelSycnParamsServiceProxyInstance
        {get; set;}
		public ISPClientCodeRelationServiceProxy SPClientCodeRelationServiceProxyInstance
        {get; set;}
		public ISPClientCodeSycnParamsServiceProxy SPClientCodeSycnParamsServiceProxyInstance
        {get; set;}
		public ISPCodeServiceProxy SPCodeServiceProxyInstance
        {get; set;}
		public ISPCodeInfoServiceProxy SPCodeInfoServiceProxyInstance
        {get; set;}
		public ISPDayReportServiceProxy SPDayReportServiceProxyInstance
        {get; set;}
		public ISPFilterRuleServiceProxy SPFilterRuleServiceProxyInstance
        {get; set;}
		public ISPMemoServiceProxy SPMemoServiceProxyInstance
        {get; set;}
		public ISPMonitoringRequestServiceProxy SPMonitoringRequestServiceProxyInstance
        {get; set;}
		public ISPParamsConvertRuleServiceProxy SPParamsConvertRuleServiceProxyInstance
        {get; set;}
		public ISPRecordServiceProxy SPRecordServiceProxyInstance
        {get; set;}
		public ISPRecordExtendInfoServiceProxy SPRecordExtendInfoServiceProxyInstance
        {get; set;}
		public ISPSClientServiceProxy SPSClientServiceProxyInstance
        {get; set;}
		public ISPSDataSycnSettingServiceProxy SPSDataSycnSettingServiceProxyInstance
        {get; set;}
		public ISPUpperServiceProxy SPUpperServiceProxyInstance
        {get; set;}




	}
}
