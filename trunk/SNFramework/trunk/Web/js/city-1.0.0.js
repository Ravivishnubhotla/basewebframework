function setcity(provinceid, cityid) {
	var province = document.getElementById(provinceid).value;
    switch (province) {
        case "海南" :
            var cityOptions = new Array(
            "海口", "海口",
            "三亚", "三亚");
             break;
        case "北京" :
            var cityOptions = new Array(
            "北京", "北京");
            break;
        case "上海" :
            var cityOptions = new Array(
            "上海", "上海");
            break;
        case "天津" :
            var cityOptions = new Array(
            "天津", "天津");
             break;
        case "重庆" :
            var cityOptions = new Array(
            "重庆", "重庆");
            break;
        case "河北" :
            var cityOptions = new Array(
            "石家庄", "石家庄",
            "邯郸", "邯郸",
            "邢台", "邢台",
            "保定", "保定",
            "张家口", "张家口",
            "承德", "承德",
            "廊坊", "廊坊",
            "唐山", "唐山",
            "秦皇岛", "秦皇岛",
            "沧州", "沧州",
            "衡水", "衡水");
            break;
        case "山西" :
            var cityOptions = new Array(
            "太原", "太原",
            "大同", "大同",
            "阳泉", "阳泉",
            "长治", "长治",
            "晋城", "晋城",
            "朔州", "朔州",
            "吕梁", "吕梁",
            "忻州", "忻州",
            "晋中", "晋中",
            "临汾", "临汾",
            "运城", "运城");
            break;

        case "内蒙古" :
            var cityOptions = new Array(
            "呼和浩特", "呼和浩特",
			"包头", "包头",
			"乌海", "乌海",
			"赤峰", "赤峰",
			"呼伦贝尔盟", "呼伦贝尔盟",
			"阿拉善盟", "阿拉善盟",
			"哲里木盟", "哲里木盟",
			"兴安盟", "兴安盟",
			"乌兰察布盟", "乌兰察布盟",
			"锡林郭勒盟", "锡林郭勒盟",
			"巴彦淖尔盟", "巴彦淖尔盟",
			"伊克昭盟", "伊克昭盟");
            break;
        case "辽宁" :
            var cityOptions = new Array(
            "沈阳", "沈阳",
            "大连", "大连",
            "鞍山", "鞍山",
            "抚顺", "抚顺",
            "本溪", "本溪",
            "丹东", "丹东",
            "锦州", "锦州",
            "营口", "营口",
            "阜新", "阜新",
            "辽阳", "辽阳",
            "盘锦", "盘锦",
            "铁岭", "铁岭",
            "朝阳", "朝阳",
            "葫芦岛", "葫芦岛");
            break;
        case "吉林" :
            var cityOptions = new Array(
            "长春", "长春",
            "吉林", "吉林",
            "四平", "四平",
            "辽源", "辽源",
            "通化", "通化",
            "白山", "白山",
            "松原", "松原",
            "白城", "白城",
            "延边", "延边");
            break;
        case "黑龙江" :
            var cityOptions = new Array(
            "哈尔滨", "哈尔滨",
            "齐齐哈尔", "齐齐哈尔",
            "牡丹江", "牡丹江",
            "佳木斯", "佳木斯",
            "大庆", "大庆",
            "绥化", "绥化",
            "鹤岗", "鹤岗",
            "鸡西", "鸡西",
            "黑河", "黑河",
            "双鸭山", "双鸭山",
            "伊春", "伊春",
            "七台河", "七台河",
            "大兴安岭", "大兴安岭");
            break;
        case "江苏" :
            var cityOptions = new Array(
            "南京", "南京",
            "镇江", "镇江",
            "苏州", "苏州",
            "南通", "南通",
            "扬州", "扬州",
            "盐城", "盐城",
            "徐州", "徐州",
            "连云港", "连云港",
            "常州", "常州",
            "无锡", "无锡",
            "宿迁", "宿迁",
			"泰州", "泰州",
            "淮安", "淮安");
            break;
        case "浙江" :
            var cityOptions = new Array(
            "杭州", "杭州",
            "宁波", "宁波",
            "温州", "温州",
            "嘉兴", "嘉兴",
            "湖州", "湖州",
            "绍兴", "绍兴",
            "金华", "金华",
            "衢州", "衢州",
            "舟山", "舟山",
            "台州", "台州",
            "丽水", "丽水");
            break;
        case "安徽" :
            var cityOptions = new Array(
            "合肥", "合肥",
            "芜湖", "芜湖",
            "蚌埠", "蚌埠",
            "马鞍山", "马鞍山",
            "淮北", "淮北",
            "铜陵", "铜陵",
            "安庆", "安庆",
            "黄山", "黄山",
            "滁州", "滁州",
            "宿州", "宿州",
            "池州", "池州",
            "淮南", "淮南",
            "巢湖", "巢湖",
            "阜阳", "阜阳",
            "六安", "六安",
            "宣城", "宣城",
            "亳州", "亳州");
            break;
        case "福建" :
            var cityOptions = new Array(
            "福州", "福州",
            "厦门", "厦门",
            "莆田", "莆田",
            "三明", "三明",
            "泉州", "泉州",
            "漳州", "漳州",
            "南平", "南平",
            "龙岩", "龙岩",
            "宁德", "宁德");
            break;
        case "江西" :
            var cityOptions = new Array(
            "南昌", "南昌",
            "抚州", "抚州",
            "赣州", "赣州",
            "吉安", "吉安",
            "景德镇", "景德镇",
            "井冈山", "井冈山",
            "九江", "九江",
            "萍乡", "萍乡",
            "上饶", "上饶",
            "宜春", "宜春",
            "新余", "新余",
            "鹰潭", "鹰潭");
            break;
        case "山东" :
            var cityOptions = new Array(
            "济南", "济南",
            "青岛", "青岛",
            "淄博", "淄博",
            "枣庄", "枣庄",
            "东营", "东营",
            "烟台", "烟台",
            "潍坊", "潍坊",
            "济宁", "济宁",
            "泰安", "泰安",
            "威海", "威海",
            "日照", "日照",
            "莱芜", "莱芜",
            "临沂", "临沂",
            "德州", "德州",
            "聊城", "聊城",
            "滨州", "滨州",
            "菏泽", "菏泽");
            break;
        case "河南" :
            var cityOptions = new Array(
            "郑州", "郑州",
            "开封", "开封",
            "洛阳", "洛阳",
            "平顶山", "平顶山",
            "安阳", "安阳",
            "鹤壁", "鹤壁",
            "新乡", "新乡",
            "焦作", "焦作",
            "濮阳", "濮阳",
            "许昌", "许昌",
            "漯河", "漯河",
            "三门峡", "三门峡",
            "南阳", "南阳",
            "商丘", "商丘",
            "信阳", "信阳",
            "周口", "周口",
            "驻马店", "驻马店",
            "济源", "济源");
            break;
        case "湖北" :
            var cityOptions = new Array(
            "武汉", "武汉",
            "宜昌", "宜昌",
            "荆州", "荆州",
            "襄樊", "襄樊",
            "黄石", "黄石",
            "荆门", "荆门",
            "黄冈", "黄冈",
            "十堰", "十堰",
            "恩施", "恩施",
            "潜江", "潜江",
            "天门", "天门",
            "仙桃", "仙桃",
            "随州", "随州",
            "咸宁", "咸宁",
            "孝感", "孝感",
            "鄂州", "鄂州");
            break;
        case "湖南" :
            var cityOptions = new Array(
            "长沙", "长沙",
            "常德", "常德",
            "株洲", "株洲",
            "湘潭", "湘潭",
            "衡阳", "衡阳",
            "岳阳", "岳阳",
            "邵阳", "邵阳",
            "益阳", "益阳",
            "娄底", "娄底",
            "怀化", "怀化",
            "郴州", "郴州",
            "永州", "永州",
            "湘西", "湘西",
            "张家界", "张家界");
            break;
        case "广东" :
            var cityOptions = new Array(
            "深圳", "深圳",
            "广州", "广州",
            "珠海", "珠海",
            "汕头", "汕头",
            "东莞", "东莞",
            "中山", "中山",
            "佛山", "佛山",
            "韶关", "韶关",
            "江门", "江门",
            "湛江", "湛江",
            "茂名", "茂名",
            "肇庆", "肇庆",
            "惠州", "惠州",
            "梅州", "梅州",
            "汕尾", "汕尾",
            "河源", "河源",
            "阳江", "阳江",
            "清远", "清远",
            "潮州", "潮州",
            "揭阳", "揭阳",
            "云浮", "云浮");
            break;
        case "广西" :
            var cityOptions = new Array(
            "南宁", "南宁",
            "柳州", "柳州",
            "桂林", "桂林",
            "梧州", "梧州",
            "北海", "北海",
            "防城港", "防城港",
            "钦州", "钦州",
            "贵港", "贵港",
            "玉林", "玉林",
            "贺州", "贺州",
            "百色", "百色",
            "河池", "河池",
            "来宾", "来宾");
            break;
        case "四川" :
            var cityOptions = new Array(
            "成都", "成都",
            "绵阳", "绵阳",
            "德阳", "德阳",
            "自贡", "自贡",
            "攀枝花", "攀枝花",
            "广元", "广元",
            "内江", "内江",
            "乐山", "乐山",
            "南充", "南充",
            "宜宾", "宜宾",
            "广安", "广安",
            "达川", "达川",
            "雅安", "雅安",
            "眉山", "眉山",
            "甘孜", "甘孜",
            "凉山", "凉山",
            "泸州", "泸州",
            "遂宁", "遂宁");
            break;
        case "贵州" :
            var cityOptions = new Array(
            "贵阳", "贵阳",
            "六盘水", "六盘水",
            "遵义", "遵义",
            "安顺", "安顺",
            "铜仁", "铜仁",
            "黔西南", "黔西南",
            "毕节", "毕节",
            "黔东南", "黔东南",
            "黔南", "黔南");
            break;
        case "云南" :
            var cityOptions = new Array(
            "昆明", "昆明",
            "大理", "大理",
            "曲靖", "曲靖",
            "玉溪", "玉溪",
            "昭通", "昭通",
            "楚雄", "楚雄",
            "红河", "红河",
            "文山", "文山",
            "思茅", "思茅",
            "西双版纳", "西双版纳",
            "保山", "保山",
            "德宏", "德宏",
            "丽江", "丽江",
            "怒江", "怒江",
            "迪庆", "迪庆",
            "临沧", "临沧");
            break;
        case "西藏" :
            var cityOptions = new Array(
            "拉萨", "拉萨",
            "日喀则", "日喀则",
            "山南", "山南",
            "林芝", "林芝",
            "昌都", "昌都",
            "阿里", "阿里",
            "那曲", "那曲");
            break;
        case "陕西" :
            var cityOptions = new Array(
            "西安", "西安",
            "宝鸡", "宝鸡",
            "咸阳", "咸阳",
            "铜川", "铜川",
            "渭南", "渭南",
            "延安", "延安",
            "榆林", "榆林",
            "汉中", "汉中",
            "安康", "安康",
            "商洛", "商洛");
            break;
        case "甘肃" :
            var cityOptions = new Array(
            "兰州", "兰州",
            "嘉峪关", "嘉峪关",
            "金昌", "金昌",
            "白银", "白银",
            "天水", "天水",
            "酒泉", "酒泉",
            "张掖", "张掖",
            "武威", "武威",
            "定西", "定西",
            "陇南", "陇南",
            "平凉", "平凉",
            "庆阳", "庆阳",
            "临夏", "临夏",
            "甘南", "甘南");
            break;
        case "宁夏" :
            var cityOptions = new Array(
            "银川", "银川",
            "石嘴山", "石嘴山",
            "吴忠", "吴忠",
            "固原", "固原");
            break;
			
        case "青海" :
            var cityOptions = new Array(
            "西宁", "西宁",
            "海东", "海东",
            "海南", "海南",
            "海北", "海北",
            "黄南", "黄南",
            "玉树", "玉树",
            "果洛", "果洛",
            "海西", "海西");
            break;			
        case "新疆" :
            var cityOptions = new Array(
            "乌鲁木齐", "乌鲁木齐",
            "石河子", "石河子",
            "克拉玛依", "克拉玛依",
            "伊犁", "伊犁",
            "巴音郭勒", "巴音郭勒",
            "昌吉", "昌吉",
            "克孜勒苏柯尔克孜", "克孜勒苏柯尔克孜",
            "博尔塔拉", "博尔塔拉",
            "吐鲁番", "吐鲁番",
            "哈密", "哈密",
            "喀什", "喀什",
            "和田", "和田",
            "阿克苏", "阿克苏");
            break;
        case "香港" :
            var cityOptions = new Array(
            "香港", "香港",
            "九龙", "九龙",
            "新界", "新界");
            break;
        case "澳门" :
            var cityOptions = new Array(
            "澳门", "澳门");
            break;
        case "台湾" :
            var cityOptions = new Array(
            "台北", "台北",
            "高雄", "高雄",
            "台中", "台中",
            "台南", "台南",
            "屏东", "屏东",
            "南投", "南投",
            "云林", "云林",
            "新竹", "新竹",
            "彰化", "彰化",
            "苗栗", "苗栗",
            "嘉义", "嘉义",
            "花莲", "花莲",
            "桃园", "桃园",
            "宜兰", "宜兰",
            "基隆", "基隆",
            "台东", "台东",
            "金门", "金门",
            "马祖", "马祖",
            "澎湖", "澎湖");
            break;
        case "海外" :
            var cityOptions = new Array(
            "马来西亚", "马来西亚",
            "新加坡", "新加坡",
            "日本", "日本",
            "美国", "美国",
            "澳大利亚", "澳大利亚",
            "印尼", "印尼",
            "英国", "英国",
            "欧洲", "欧洲",
            "北美", "北美",
            "南美", "南美",
            "亚洲", "亚洲",
            "非洲", "非洲",
            "大洋洲", "大洋洲");
            break;
        default:
            var cityOptions = new Array("选择城市", "");
            break;
    }
	
	var cityObject = document.getElementById(cityid);
	cityObject.options.length = 0;
	cityObject.options[0] = new Option("选择城市", "");
	var j = 0;
	for(var i = 0; i < cityOptions.length/2; i++) {
		j = i + 1;
	    cityObject.options[j] = new Option(cityOptions[i*2],cityOptions[i*2+1]);
	}
}

function init_province(provinceid, province) {
	var provObject = document.getElementById(provinceid);
    for(var i = 0; i < provObject.options.length; i++) {
        if (provObject.options[i].value == province) {
        	provObject.selectedIndex = i;
			break;
        }
    }
    //setcity(provinceid, cityid);
}


function init_city(cityid, city) {
	var cityObject = document.getElementById(cityid);
    for(var i = 0; i < cityObject.options.length; i++) {
        if (cityObject.options[i].value == city) {
        	cityObject.selectedIndex = i;
			break;
        }
    }
    //setcity(provinceid, cityid);
}



function showprovince(provinceid, cityid, province) {
	var provinces = new Array(
		"海南", "北京", "上海", "天津", "重庆", "河北", "山西", "内蒙古", "辽宁", "吉林", "黑龙江", "江苏", "浙江",
		"安徽", "福建", "江西", "山东", "河南", "湖北", "湖南", "广东", "广西", "四川", "贵州", "云南",
		"西藏", "陕西", "甘肃", "宁夏", "青海", "新疆", "香港", "澳门", "台湾", "海外"
	);

	var html = "<select name=\"" + provinceid + "\" id=\"" + provinceid + "\" onchange=\"setcity('" + provinceid + "', '" + cityid + "');\">";
	html = html + "<option value=\"\">选择省份</option>";
	for(var i = 0; i < provinces.length; i++) {
		html = html + "<option value=\"" + provinces[i] + "\">" + provinces[i] + "</option>";
	}
	html = html + "</select>";
	document.write(html);
	init_province(provinceid, province);
}

function showcity(provinceid, cityid, city) {
	var html = "&nbsp;<select name=\"" + cityid + "\" id=\"" + cityid + "\">";
	html = html + "</select>";
	document.write(html);
	setcity(provinceid, cityid);
	init_city(cityid, city);
}