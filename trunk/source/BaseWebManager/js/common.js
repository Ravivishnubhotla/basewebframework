
var __ie6 = /msie 6/i.test(window.navigator.userAgent);

function OpenDialogHelper(){};

OpenDialogHelper.openModalDlg = function(sPath, oArgs, iX, iY)
{
    //��ʵ�ʲ���ʹ��ʱ��Ӧ������һ�д����ע�͡�
    //
    //��Ϊվ��һ�㲻�ᱻ�û�����ΪLocal intranet������IE6ģ̬�����л����״̬����
    //����IE6��ģ̬���ڸ߶�ָ�������ڵĸ߶ȣ������Ǵ����п�����ʾ����ĸ߶ȡ�
    //���״̬���ᵲס�����²��Ľ��棬Ӱ��ʹ�á�
    //
    if(__ie6) iY += 20;
    
    //IE7�е�dialogWidth��dialogHeight������ֵ��ָ�Ŀ�͸ߣ����������ڵı���������߿�IE6������
    //��ϧ�ͻ��˽������޷�ͨ���ű���á���WinXP��WinClassic����У��������ĸ߶��ǲ�ͬ�ġ�
    if(__ie6)
    {
        iX += 6;
        iY += 32;   //WinXP������
        //iY += 25; //WinClassic������
    }
	return window.showModalDialog(sPath, oArgs, "dialogWidth:" + iX + "px;dialogHeight:" + iY + "px;help:0;status:0;scroll:0;center:1");
};