namespace CargoGo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CargoGo.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CargoGo.Models.MyDBContext>
    {
        public Configuration()
        {
            //是否自动将Model类的设计改变映射到数据库，默认false
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CargoGo.Models.MyDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //context.Trucks.Add(new Truck("渝B3178", "大型板车"));
            //context.Trucks.Add(new Truck("川W62945", "大型货车","关羽"));
            //context.Trucks.Add(new Truck("川W23998", "大型货车", "张飞","11011001100"));
            //context.Companies.Add(new Company { CompanyName = "攀枝花市正源科技有限责任公司" });
            InsertBankAccountRecrods(context);
            InsertCompanyRecords(context);
            InsertComapnyDeliveryAddressRecords(context);
            InsertContractRecords(context);
            InsertDirectionRecords(context);
            InsertInvoiceRecords(context);
            context.PaymentTypes.AddOrUpdate(new PaymentType { ID = 1, PaymentTypeCode = "AABE", PaymentTypeDesc = "承兑汇票(银行)" });
            context.PaymentTypes.AddOrUpdate(new PaymentType { ID = 2, PaymentTypeCode = "BAER", PaymentTypeDesc = "实物交易" });
            context.PaymentTypes.AddOrUpdate(new PaymentType { ID = 3, PaymentTypeCode = "DEBT", PaymentTypeDesc = "欠款" });
            context.PaymentTypes.AddOrUpdate(new PaymentType { ID = 4, PaymentTypeCode = "RECO", PaymentTypeDesc = "对账调整" });
            context.PaymentTypes.AddOrUpdate(new PaymentType { ID = 5, PaymentTypeCode = "TRER", PaymentTypeDesc = "银行转账" });
            context.Payments.AddOrUpdate(new Payment { ID = 1, PaymentDate = new DateTime(2016, 1, 1), PaymentDirectionCode = "IN", CompanyCode = "HZGH", PaymentTypeCode = "DEBT", PaymentAmount = -1872650, Note = "来自张婷“2016销售汇总表”》“杭州广翰”》2016年10月9日至11月30日共计8条记录1,870,300元+此前一条记录的尾款2,350元。" });
            context.Payments.AddOrUpdate(new Payment { ID = 2, PaymentDate = new DateTime(2016, 4, 8), PaymentDirectionCode = "IN", CompanyCode = "JMAG", PaymentTypeCode = "TRER", PaymentAmount = 9802 });
            context.Payments.AddOrUpdate(new Payment { ID = 3, PaymentDate = new DateTime(2016, 4, 8), PaymentDirectionCode = "IN", CompanyCode = "JMAG", PaymentTypeCode = "RECO", PaymentAmount = -9802, Note = "发货明细表中缺少2016年4月8日此笔货款对应的发货记录，故此调整。" });
            context.Products.AddOrUpdate(new Product { ID = 1, ProductCode = "ZY6601A", ProductName = "钛钨粉", Note = "钛钨复合粉，含5%WO3，用于火电厂SCR脱硝催化剂制造。" });
            context.Products.AddOrUpdate(new Product { ID = 2, ProductCode = "ZY6601C", ProductName = "钛钨粉", Note = "钛钨复合粉，含约10%WO3，用于柴油机SCR脱硝催化剂制造。" });
            context.Products.AddOrUpdate(new Product { ID = 3, ProductCode = "ZY6602A", ProductName = "钛钨硅粉", Note = "(适用于JM公司,以前被认为是HT6602AL)：钛钨硅复合粉，含5%WO3，5%SiO2,用于柴油机SCR脱硝催化剂制造。" });
            //context.Configuration.ProxyCreationEnabled = false;
        }

        private void InsertBankAccountRecrods(CargoGo.Models.MyDBContext context)
        {
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 1, CompanyCode = "ZYKJ", BankName = "攀枝花市农村商业银行股份有限公司米易县支行", BankAccount = "13370120000005696", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 2, CompanyCode = "ZYKJ", BankName = "农业银行米易城关分理处", BankAccount = "22147601040002098", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 3, CompanyCode = "ZYKJ", BankName = "BANK OF CHINA", BankAccount = "123939187710", CurrencyCode = "USD", Note = "Beneficaiary: PANZHIHUA ZHENGYUAN TECHNOLOGY CO.LTD;SWIFT CODE: BKCHCNBJ570;Bank Address: NO.368 RENMIN STREET EAST DISTRICT, PANZHIHUA, SICHUAN,CHINA." });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 4, CompanyCode = "CQXH", BankName = "农行潼南县支行营业部", BankAccount = "31-190101040002137", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 5, CompanyCode = "QDSC", BankName = "中行胶州支行", BankAccount = "223426678178", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 6, CompanyCode = "SDDY", BankName = "中国建设银行广饶支行", BankAccount = "37001655901050154090", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 7, CompanyCode = "SHSY", BankName = "中国工商银行上海浦东开发区支行", BankAccount = "1001281209006815620", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 8, CompanyCode = "WXHG", BankName = "中国工商银行无锡泰伯支行", BankAccount = "1103030309000027212", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 9, CompanyCode = "XAYC", BankName = "中国银行股份有限公司西安长乐路支行", BankAccount = "103633992245", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 10, CompanyCode = "XAQY", BankName = "交通银行西安东开发区支行", BankAccount = "611301036018010056482", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 11, CompanyCode = "HNJS", BankName = "农业银行鹤煤支行", BankAccount = "16-431601040002358", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 12, CompanyCode = "ZJDC", BankName = "中国银行绍兴高新技术开发区支行", BankAccount = "351958355889", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 13, CompanyCode = "SHHY", BankName = "中国建设银行松江支行", BankAccount = "31001937710050016212", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 14, CompanyCode = "HBHE", BankName = "工商银行宁晋支行", BankAccount = "0406001309300007796", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 15, CompanyCode = "PGTY", BankName = "建行瓜子坪支行", BankAccount = "51001627337059381688", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 16, CompanyCode = "ZJZN", BankName = "工行宁海金水支行", BankAccount = "3901330109000035053", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 17, CompanyCode = "ZZHB", BankName = "建行成都高新西区支行", BankAccount = "51001408537051501357", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 18, CompanyCode = "JSLQ", BankName = "中国建设银行淮安市经济技术开发区支行", BankAccount = "32050172533600000240", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 19, CompanyCode = "ZJSW", BankName = "浙江长兴农村合作银行洪桥支行", BankAccount = "201000014954779", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 20, CompanyCode = "DDHX", BankName = "交通银行福春支行", BankAccount = "216005030010211000649", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 21, CompanyCode = "SCXZ", BankName = "中国农业银行股份有限公司绵竹市支行", BankAccount = "22204101040026866", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 22, CompanyCode = "TYKJ", BankName = "中国农业银行攀枝花新华街支行", BankAccount = "2213250140003491", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 23, CompanyCode = "DFTY", BankName = "中国农业银行米易县支行", BankAccount = "22147101040011108", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 24, CompanyCode = "HTKJ", BankName = "中国工商银行股份有限公司攀枝花分行", BankAccount = "2302332109100129426", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 25, CompanyCode = "ZRSM", BankName = "攀枝花市商业银行股份有限公司炳草岗支行", BankAccount = "77220100012889234", CurrencyCode = "CNY" });
            context.BankAccouts.AddOrUpdate(new BankAccout { ID = 26, CompanyCode = "JYKJ", BankName = "工商银行攀枝花分行营业部", BankAccount = "2302332109100109587", CurrencyCode = "CNY" });
        }

        private void InsertCompanyRecords(CargoGo.Models.MyDBContext context)
        {
            context.Companies.AddOrUpdate(new Company { ID = 1, CompanyCode = "AHYC", ShortName = "安徽元琛环保科技", FullName = "安徽元琛环保科技股份有限公司", BusinessDirectionCode = "BOTH", PhoneNumber = "0551-64266332", FaxNumber = "0551-66335361", Website = "http://www.shychb.com/default.asp", Address = "中国安徽省合肥市新站高新技术产业开发区", TaxNumber = "913401007749523631" });
            context.Companies.AddOrUpdate(new Company { ID = 2, CompanyCode = "CQXH", ShortName = "重庆新华化工", FullName = "重庆新华化工有限公司", BusinessDirectionCode = "BOTH", PhoneNumber = "023-87288166", FaxNumber = "023-87288166", Address = "重庆市潼南县桂林镇街道办事处民业街298号", TaxNumber = "91500223202910336J", SalesContact = "裴健", SalesContactMobile = "13896169609", SalesContactEmail = "2697853353@qq.com" });
            context.Companies.AddOrUpdate(new Company { ID = 3, CompanyCode = "DDAD", ShortName = "丹东安迪亚科技", FullName = "丹东安迪亚科技有限公司", BusinessDirectionCode = "BOTH", Address = "丹东市国门大道19号1单元1601室", TaxNumber = "91210600MA0U9LN82E" });
            context.Companies.AddOrUpdate(new Company { ID = 4, CompanyCode = "DDHX", ShortName = "丹东市化学试剂厂", FullName = "丹东市化学试剂厂", BusinessDirectionCode = "BOTH", Address = "辽宁省丹东市振兴区浪头镇中和村393号", TaxNumber = "91210600120212091B", PhoneNumber = "0415-6155014" });
            context.Companies.AddOrUpdate(new Company { ID = 5, CompanyCode = "DFTY", ShortName = "攀枝花东方钛业", FullName = "攀枝花东方钛业有限公司", BusinessDirectionCode = "BOTH", Address = "攀枝花市米易县丙谷镇", TaxNumber = "91510421789118240N", PhoneNumber = "0812-8102290" });
            context.Companies.AddOrUpdate(new Company { ID = 6, CompanyCode = "DLWL", ShortName = "攀枝花大辂物流", FullName = "攀枝花大辂物流有限公司", BusinessDirectionCode = "BOTH" });
            context.Companies.AddOrUpdate(new Company { ID = 7, CompanyCode = "HBHE", ShortName = "河北惠尔信新材料", FullName = "河北惠尔信新材料有限公司", BusinessDirectionCode = "BOTH", Address = "河北省宁晋县宁辛路36号", TaxNumber = "91130528737368715C", PhoneNumber = "0319-5850689" });
            context.Companies.AddOrUpdate(new Company { ID = 8, CompanyCode = "HDMY", ShortName = "环达贸易", BusinessDirectionCode = "BOTH" });
            context.Companies.AddOrUpdate(new Company { ID = 9, CompanyCode = "HNJS", ShortName = "河南金山环保科技工业园", FullName = "河南金山环保科技工业园有限公司", BusinessDirectionCode = "BOTH", Address = "鹤壁市淇滨区延河路与华夏北路交叉口", TaxNumber = "410618685679086", PhoneNumber = "0392-2217444" });
            context.Companies.AddOrUpdate(new Company { ID = 1013, CompanyCode = "HTKJ", ShortName = "攀枝花汇钛科技", FullName = "攀枝花汇钛科技有限责任公司", BusinessDirectionCode = "BOTH", Address = "攀枝花市东区临江路78号2幢二单元", TaxNumber = "915104023144306954", SalesContact = "钱先生", SalesContactMobile = "18508123185" });
            context.Companies.AddOrUpdate(new Company { ID = 1014, CompanyCode = "HZGH", ShortName = "浙江广翰环保科技（杭州广翰能源科技）", FullName = "浙江广翰环保科技股份有限公司（杭州广翰能源科技）", BusinessDirectionCode = "BOTH" });
            context.Companies.AddOrUpdate(new Company { ID = 1015, CompanyCode = "JCWL", ShortName = "无锡尖驰运输", FullName = "无锡尖驰运输有限公司", BusinessDirectionCode = "BOTH" });
            context.Companies.AddOrUpdate(new Company { ID = 1016, CompanyCode = "JMAG", ShortName = "庄信万丰（阿根廷）" });
            context.Companies.AddOrUpdate(new Company { ID = 1017, CompanyCode = "JMEG", ShortName = "庄信万丰（英国）" });
            context.Companies.AddOrUpdate(new Company { ID = 1018, CompanyCode = "JMIN", ShortName = "庄信万丰（印度）" });
            context.Companies.AddOrUpdate(new Company { ID = 1019, CompanyCode = "JMSA", ShortName = "庄信万丰（南非）" });
            context.Companies.AddOrUpdate(new Company { ID = 1020, CompanyCode = "JSLQ", ShortName = "江苏龙清环境技术", FullName = "江苏龙清环境技术有限公司", BusinessDirectionCode = "BOTH", Address = "江苏省淮安市经济技术开发区景秀路18号", TaxNumber = "91320891MA1MKRNY6Q", PhoneNumber = "0517-83730868", FaxNumber = "0517-83730868" });
            context.Companies.AddOrUpdate(new Company { ID = 1021, CompanyCode = "JYKJ", ShortName = "攀枝花市精研科技", FullName = "攀枝花市精研科技有限公司", BusinessDirectionCode = "BOTH", Address = "攀枝花市机场路10号（学府广场3号楼二楼249号房间）", TaxNumber = "91510400MA62111B4P", SalesContactMobile = "13982347124" });
            context.Companies.AddOrUpdate(new Company { ID = 1022, CompanyCode = "JYWL", ShortName = "成都嘉樾物流", FullName = "成都嘉樾物流有限公司", BusinessDirectionCode = "BOTH" });
            context.Companies.AddOrUpdate(new Company { ID = 1023, CompanyCode = "KHSM", ShortName = "攀枝花市凯浩商贸", FullName = "攀枝花市凯浩商贸有限公司", BusinessDirectionCode = "BOTH" });
            context.Companies.AddOrUpdate(new Company { ID = 1024, CompanyCode = "LBDP", ShortName = "宁波德普净化器", FullName = "宁波德普净化器有限公司", BusinessDirectionCode = "BOTH", Address = "宁波市宁海县西店镇西店北路1087号", TaxNumber = "913302267204256132", PhoneNumber = "0574-65187702" });
            context.Companies.AddOrUpdate(new Company { ID = 1025, CompanyCode = "LBFS", ShortName = "宁波德普福斯特环保科技", FullName = "宁波德普福斯特环保科技有限公司", BusinessDirectionCode = "BOTH", Address = "宁海县力洋镇金海东路5号金港创业基地", TaxNumber = "913302263168774152", PhoneNumber = "0574-65187702" });
            context.Companies.AddOrUpdate(new Company { ID = 1026, CompanyCode = "LCWL", ShortName = "攀枝花市朗程汽车运输", FullName = "攀枝花市朗程汽车运输有限公司", BusinessDirectionCode = "BOTH" });
            context.Companies.AddOrUpdate(new Company { ID = 1027, CompanyCode = "PGTY", ShortName = "攀钢集团钛业", FullName = "攀钢集团钛业有限责任公司", BusinessDirectionCode = "BOTH", Address = "攀枝花市钒钛产业园区", TaxNumber = "91510400765069034P", PhoneNumber = "0812-3381681" });
            context.Companies.AddOrUpdate(new Company { ID = 1028, CompanyCode = "QDSC", ShortName = "青岛晟驰环保科技", FullName = "青岛晟驰环保科技有限公司", BusinessDirectionCode = "BOTH", Address = "山东省青岛市胶州市海尔大道69号", TaxNumber = "913702813340859567", PhoneNumber = "0532-83987983" });
            context.Companies.AddOrUpdate(new Company { ID = 1029, CompanyCode = "QDWL", ShortName = "成都钦怛物流", FullName = "成都钦怛物流有限公司", BusinessDirectionCode = "BOTH" });
            context.Companies.AddOrUpdate(new Company { ID = 1030, CompanyCode = "SCXZ", ShortName = "四川旭洲科技", FullName = "四川旭洲科技有限公司", BusinessDirectionCode = "BOTH", Address = "四川省绵竹市剑南镇紫岩路74号", TaxNumber = "91510683MA621UXJ25" });
            context.Companies.AddOrUpdate(new Company { ID = 1031, CompanyCode = "SDDY", ShortName = "山东东源新材料科技", FullName = "山东东源新材料科技有限公司", BusinessDirectionCode = "BOTH", Address = "东营市广饶县经济开发区（月河路以东，15号路以南）", TaxNumber = "91370523790389021N", PhoneNumber = "0551-64266332", FaxNumber = "0551-66335361" });
            context.Companies.AddOrUpdate(new Company { ID = 1032, CompanyCode = "SHHY", ShortName = "上海瀚昱环保材料", FullName = "上海瀚昱环保材料有限公司", BusinessDirectionCode = "BOTH", Address = "上海市松江区鼎源路618弄1号22幢205室", TaxNumber = "91310117798963577X", PhoneNumber = "021-67720661" });
            context.Companies.AddOrUpdate(new Company { ID = 1033, CompanyCode = "SHSJ", ShortName = "上海四极国际贸易", FullName = "上海四极国际贸易有限公司", BusinessDirectionCode = "BOTH" });
            context.Companies.AddOrUpdate(new Company { ID = 1034, CompanyCode = "SHSY", ShortName = "上海硕婴实业", FullName = "上海硕婴实业有限公司", BusinessDirectionCode = "BOTH", Address = "上海长宁区中山西路999号", TaxNumber = "91310117690126152T", PhoneNumber = "021-65360667" });
            context.Companies.AddOrUpdate(new Company { ID = 1035, CompanyCode = "SZLC", ShortName = "苏州莲池环保科技发展", FullName = "苏州莲池环保科技发展有限公司", BusinessDirectionCode = "BOTH", Address = "昆山市玉山镇国际模具城模具制造区13号楼", TaxNumber = "91320583323872532Q", PhoneNumber = "0512-36615903" });
            context.Companies.AddOrUpdate(new Company { ID = 1036, CompanyCode = "TDHG", ShortName = "攀枝花市钛都化工", FullName = "攀枝花市钛都化工有限公司", BusinessDirectionCode = "BOTH" });
            context.Companies.AddOrUpdate(new Company { ID = 1037, CompanyCode = "TYKJ", ShortName = "攀枝花天屹新材料科技", FullName = "攀枝花天屹新材料科技有限公司", BusinessDirectionCode = "BOTH", Address = "攀枝花市盐边县安宁工业园区三棵树", TaxNumber = "915104223378433536", PhoneNumber = "0812-5567527", FaxNumber = "0812-5567527" });
            context.Companies.AddOrUpdate(new Company { ID = 1038, CompanyCode = "WXHG", ShortName = "无锡华光新动力环保科技", FullName = "无锡华光新动力环保科技股份有限公司", BusinessDirectionCode = "BOTH", Address = "江苏省无锡市滨湖区梅育路123号", TaxNumber = "913202005753826522", PhoneNumber = "0510-81153410" });
            context.Companies.AddOrUpdate(new Company { ID = 1039, CompanyCode = "XAQY", ShortName = "启源（西安）大荣环保科技", FullName = "启源（西安）大荣环保科技有限公司", BusinessDirectionCode = "BOTH", Address = "西安市凤城十二路98号西安启源机电装备股份有限公司内", TaxNumber = "916101320810087247", PhoneNumber = "029-86403190" });
            context.Companies.AddOrUpdate(new Company { ID = 1040, CompanyCode = "XAYC", ShortName = "西安元创化工科技", FullName = "西安元创化工科技股份有限公司", BusinessDirectionCode = "BOTH", Address = "西安市临潼区火车站街1号（西北化工研究院内）", TaxNumber = "610115059677374", PhoneNumber = "029-83870028" });
            context.Companies.AddOrUpdate(new Company { ID = 1041, CompanyCode = "XGZL", ShortName = "香港卓力", BusinessDirectionCode = "BOTH" });
            context.Companies.AddOrUpdate(new Company { ID = 1042, CompanyCode = "ZJDC", ShortName = "浙江德创环保科技", FullName = "浙江德创环保科技股份有限公司", BusinessDirectionCode = "BOTH", Address = "绍兴袍江工业区越东路与三江路交叉口", TaxNumber = "绍兴袍江工业区越东路与三江路交叉口", PhoneNumber = "0575-88556095", FaxNumber = "0575-88556036" });
            context.Companies.AddOrUpdate(new Company { ID = 1043, CompanyCode = "ZJSW", ShortName = "浙江盛旺环保科技", FullName = "浙江盛旺耐火材料股份有限公司", BusinessDirectionCode = "BOTH", Address = "浙江省长兴县洪桥工业园区", TaxNumber = "330522767976906（旧）", PhoneNumber = "0572-6064071" });
            context.Companies.AddOrUpdate(new Company { ID = 1044, CompanyCode = "ZJZN", ShortName = "浙江浙能催化剂技术", FullName = "浙江浙能催化剂技术有限公司", BusinessDirectionCode = "BOTH", Address = "宁波市宁海县强蛟镇宁海湾循环经济开发区望岗路1号", TaxNumber = "91330226573682264P", PhoneNumber = "0574-82531120" });
            context.Companies.AddOrUpdate(new Company { ID = 1045, CompanyCode = "ZRSM", ShortName = "攀枝花市中瑞商贸", FullName = "攀枝花市中瑞商贸有限公司", BusinessDirectionCode = "BOTH", Address = "攀枝花市仁和区金江钒钛工业园区", TaxNumber = "915104003270206014", PhoneNumber = "915104003270206014" });
            context.Companies.AddOrUpdate(new Company { ID = 1046, CompanyCode = "ZYKJ", ShortName = "攀枝花市正源科技", FullName = "攀枝花市正源科技有限责任公司", BusinessDirectionCode = "BASE", Address = "四川省攀枝花市米易县丙谷镇椅子山钒钛工业园", TaxNumber = "915104215883832326", PhoneNumber = "0812-8176537", FaxNumber = "0812-8176537", SalesContact = "邓鹏", SalesContactMobile = "15983558907", SalesContactEmail = "32211001@qq.com", AccountingContact = "王波", AccountingContactMobile = "13982382134", AccountingContactEmail = "616702962@qq.com" });
            context.Companies.AddOrUpdate(new Company { ID = 1047, CompanyCode = "ZZHB", ShortName = "中自环保科技", FullName = "中自环保科技股份有限公司", BusinessDirectionCode = "BOTH", Address = "成都市高新区古楠街88号", TaxNumber = "91510100777457894E", PhoneNumber = "028-62825888" });
        }

        private void InsertComapnyDeliveryAddressRecords(CargoGo.Models.MyDBContext context)
        {
            context.CompanyDeliveryAddresses.AddOrUpdate(new CompanyDeliveryAddress { ID = 4, CompanyCode = "HNJS", CargoDeliveryAddress = "河南鹤壁市淇滨区延河路228号河南金山环保科技工业园有限公司厂区内", CargoDeliveryContact = "董颖磊", CargoDeliveryContactMobile = "13333928191" });
            context.CompanyDeliveryAddresses.AddOrUpdate(new CompanyDeliveryAddress { ID = 5, CompanyCode = "XAQY", CargoDeliveryAddress = "陕西省西安市经济技术开发区凤城十二路98号", CargoDeliveryContact = "李春霞", CargoDeliveryContactMobile = "18710600956" });
            context.CompanyDeliveryAddresses.AddOrUpdate(new CompanyDeliveryAddress { ID = 6, CompanyCode = "QDSC", CargoDeliveryAddress = "山东省济宁市鱼台县王庙镇", CargoDeliveryContact = "马汉文", CargoDeliveryContactMobile = "15275761665" });
        }

        private void InsertContractRecords(CargoGo.Models.MyDBContext context)
        {
            context.Contracts.AddOrUpdate(new Contract { ID = 1, ContractCode = "2015年欠款", ContractDate = new DateTime(2015, 9, 24), CompanyCode = "ZJZN", ProductCode = "ZY6609A", ContractAmount = 35, ContractPrice = 11000, Note = "已付清。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 2, ContractCode = "20160501-1", ContractDate = new DateTime(2016, 5, 1), CompanyCode = "SHHY", ProductCode = "ZY6601A", ContractAmount = 56, ContractPrice = 15300, Note = "补录2016年欠款数据。8月15日，发票（08753223）1,344,870元。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 3, ContractCode = "20160501-2", ContractDate = new DateTime(2016, 5, 1), CompanyCode = "SHHY", ProductCode = "ZY6602B", ContractAmount = 32, ContractPrice = 15300, Note = "补录2016年欠款数据。8月15日，发票（08753223）1,344,870元，补录此发货记录。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 4, ContractCode = "2016-002", ContractDate = new DateTime(2016, 7, 20), CompanyCode = "SDDY", ProductCode = "ZY6609A", ContractAmount = 72, ContractPrice = 12200, Note = "补录2016年欠款数据。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 5, ContractCode = "2016-003", ContractDate = new DateTime(2016, 7, 21), CompanyCode = "SDDY", ProductCode = "ZY6609A", ContractAmount = 93, ContractPrice = 12000, Note = "补录2016年欠款数据。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 6, ContractCode = "2016年欠款", ContractDate = new DateTime(2016, 8, 23), CompanyCode = "HNJS", ProductCode = "ZY6609A", ContractAmount = 63, ContractPrice = 9100, Note = "已付款131600来自张婷2016账目。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 7, ContractCode = "20161020", ContractDate = new DateTime(2016, 10, 20), CompanyCode = "SHHY", ProductCode = "ZY6601A", ContractAmount = 36, ContractPrice = 15500, Note = "2016年欠款。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 8, ContractCode = "20161024", ContractDate = new DateTime(2016, 10, 24), CompanyCode = "SHHY", ProductCode = "ZY6609A", ContractAmount = 31, ContractPrice = 9800, Note = "2016年欠款。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 9, ContractCode = "20161104", ContractDate = new DateTime(2016, 11, 4), CompanyCode = "SHHY", ProductCode = "ZY6609A", ContractAmount = 30, ContractPrice = 10300, Note = "2016年欠款。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 10, ContractCode = "WHEC2016-75B", ContractDate = new DateTime(2016, 12, 15), CompanyCode = "WXHG", ProductCode = "ZY6601A", ContractPrice = 217000, Note = "此合同吨位和单价不确定，为数据完整性暂时填入，如要确定需找原件核对。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 11, ContractCode = "20170307-HTKJ01", ContractDate = new DateTime(2017, 3, 7), CompanyCode = "HTKJ", ProductCode = "ZY6606G", ContractAmount = 200, ContractPrice = 12600 });
            context.Contracts.AddOrUpdate(new Contract { ID = 12, ContractCode = "20170308-SHSY01", ContractDate = new DateTime(2017, 3, 8), CompanyCode = "SHSY", ProductCode = "ZY6601A", ContractAmount = 100, ContractPrice = 18500 });
            context.Contracts.AddOrUpdate(new Contract { ID = 13, ContractCode = "DTY-201703-018", ContractDate = new DateTime(2017, 3, 13), CompanyCode = "DFTY", ProductCode = "ZY6606G", ContractAmount = 300, ContractPrice = 12800 });
            context.Contracts.AddOrUpdate(new Contract { ID = 14, ContractCode = "TUNA-M201703054", ContractDate = new DateTime(2017, 3, 17), CompanyCode = "ZJDC", ProductCode = "ZY6609A", ContractAmount = 200, ContractPrice = 15600 });
            context.Contracts.AddOrUpdate(new Contract { ID = 15, ContractCode = "CQXH20170327-01", ContractDate = new DateTime(2017, 3, 27), CompanyCode = "CQXH", ProductCode = "ZY6606G", ContractAmount = 300, ContractPrice = 13800, Note = "3月30日至5月11日实际执行数量392.81吨。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 16, ContractCode = "ZY20170207", ContractDate = new DateTime(2017, 3, 30), CompanyCode = "CQXH", ProductCode = "ZY6606G", ContractAmount = 6, ContractPrice = 12400, Note = "此记录为从3月30日所发31.48吨中分出6.18吨合计为上一个300吨合同凑整。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 17, ContractCode = "HBHEX20170331-1", ContractDate = new DateTime(2017, 3, 31), CompanyCode = "HBHE", ProductCode = "ZY6601A", ContractAmount = 200, ContractPrice = 16300, Note = "库存品，自提，按实际发货量结算。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 18, ContractCode = "WHEC2017-SCHT-02509", ContractDate = new DateTime(2017, 4, 21), CompanyCode = "WXHG", ProductCode = "ZY6609A", ContractPrice = 15050, Note = "为避免合同编号重复，此条记录由“WHEC2017-SCHT-025”修改为“WHEC2017-SCHT-02509”。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 19, ContractCode = "WHEC2017-SCHT-025", ContractDate = new DateTime(2015, 4, 21), CompanyCode = "WXHG", ProductCode = "ZY6601A", ContractPrice = 21700 });
            context.Contracts.AddOrUpdate(new Contract { ID = 20, ContractCode = "TUNA-M201705002", ContractDate = new DateTime(2017, 4, 28), CompanyCode = "ZJDC", ProductCode = "ZY6609A", ContractAmount = 200, ContractPrice = 15600 });
            context.Contracts.AddOrUpdate(new Contract { ID = 21, ContractCode = "20170503-SHHY09", ContractDate = new DateTime(2017, 5, 3), CompanyCode = "SHHY", ProductCode = "ZY6609A", ContractAmount = 30, ContractPrice = 15400 });
            context.Contracts.AddOrUpdate(new Contract { ID = 22, ContractCode = "DTY-201705-001", ContractDate = new DateTime(2017, 5, 3), CompanyCode = "DFTY", ProductCode = "ZY6606G", ContractAmount = 100, ContractPrice = 13300 });
            context.Contracts.AddOrUpdate(new Contract { ID = 23, ContractCode = "CQXH20170509-01", ContractDate = new DateTime(2017, 5, 9), CompanyCode = "CQXH", ProductCode = "ZY6606G", ContractAmount = 200, ContractPrice = 13800 });
            context.Contracts.AddOrUpdate(new Contract { ID = 24, ContractCode = "20170509-HTKJ01", ContractDate = new DateTime(2017, 5, 9), CompanyCode = "HTKJ", ProductCode = "ZY6606G", ContractAmount = 120, ContractPrice = 13500 });
            context.Contracts.AddOrUpdate(new Contract { ID = 25, ContractCode = "20170525JYKJ06", ContractDate = new DateTime(2017, 5, 25), CompanyCode = "JYKJ", ProductCode = "ZY6606D", ContractAmount = 30, ContractPrice = 14300 });
            context.Contracts.AddOrUpdate(new Contract { ID = 26, ContractCode = "20170522QDT47", ContractDate = new DateTime(2017, 5, 31), CompanyCode = "XAQY", ProductCode = "ZY6609A", ContractAmount = 14, ContractPrice = 16000 });
            context.Contracts.AddOrUpdate(new Contract { ID = 27, ContractCode = "20170522QDT46", ContractDate = new DateTime(2017, 5, 31), CompanyCode = "XAQY", ProductCode = "ZY6601A", ContractAmount = 54, ContractPrice = 22500 });
            context.Contracts.AddOrUpdate(new Contract { ID = 28, ContractCode = "20170608YCHB09", ContractDate = new DateTime(2017, 6, 8), CompanyCode = "AHYC", ProductCode = "ZY6609A", ContractPrice = 16200 });
            context.Contracts.AddOrUpdate(new Contract { ID = 29, ContractCode = "20170621-HTKJ06", ContractDate = new DateTime(2017, 6, 21), CompanyCode = "HTKJ", ProductCode = "ZY6606G", ContractAmount = 150, ContractPrice = 12800, Note = "自提。其转发山东客户。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 30, ContractCode = "CQXH2017062609", ContractDate = new DateTime(2017, 6, 26), CompanyCode = "CQXH", ProductCode = "ZY6609A", ContractAmount = 30, ContractPrice = 14400, Note = "颗粒料。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 31, ContractCode = "CQXH2017062606", ContractDate = new DateTime(2017, 6, 26), CompanyCode = "CQXH", ProductCode = "ZY6606G", ContractAmount = 100, ContractPrice = 12800 });
            context.Contracts.AddOrUpdate(new Contract { ID = 32, ContractCode = "20170627HBHE09", ContractDate = new DateTime(2017, 7, 2), CompanyCode = "HBHE", ProductCode = "ZY6609A", ContractAmount = 32, ContractPrice = 14000 });
            context.Contracts.AddOrUpdate(new Contract { ID = 33, ContractCode = "LQ20170706", ContractDate = new DateTime(2017, 7, 6), CompanyCode = "JSLQ", ProductCode = "ZY6606G", ContractAmount = 200, ContractPrice = 13100 });
            context.Contracts.AddOrUpdate(new Contract { ID = 34, ContractCode = "20170711HTKJ06", ContractDate = new DateTime(2017, 7, 7), CompanyCode = "HTKJ", ProductCode = "ZY6606G", ContractAmount = 200, ContractPrice = 11800 });
            context.Contracts.AddOrUpdate(new Contract { ID = 35, ContractCode = "CQXH2017071406", ContractDate = new DateTime(2017, 7, 8), CompanyCode = "CQXH", ProductCode = "ZY6606G", ContractAmount = 200, ContractPrice = 12600 });
            context.Contracts.AddOrUpdate(new Contract { ID = 36, ContractCode = "20170717SHSY01", ContractDate = new DateTime(2017, 7, 17), CompanyCode = "SHSY", ProductCode = "ZY6601A", ContractAmount = 30, ContractPrice = 22500 });
            context.Contracts.AddOrUpdate(new Contract { ID = 37, ContractCode = "20170717SHSY02", ContractDate = new DateTime(2017, 7, 17), CompanyCode = "SHSY", ProductCode = "ZY6602B", ContractAmount = 30, ContractPrice = 22500, Note = "为避免合同编号重复，此条记录由“20170717SHSY01”修改为“20170717SHSY02”。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 38, ContractCode = "20170717XAYC02", ContractDate = new DateTime(2017, 7, 17), CompanyCode = "XAYC", ProductCode = "ZY6602B", ContractAmount = 3, ContractPrice = 22200 });
            context.Contracts.AddOrUpdate(new Contract { ID = 39, ContractCode = "20170718CQXH06", ContractDate = new DateTime(2017, 7, 18), CompanyCode = "CQXH", ProductCode = "ZY6606G", ContractAmount = 200, ContractPrice = 12600 });
            context.Contracts.AddOrUpdate(new Contract { ID = 40, ContractCode = "20170719DDHX06", ContractDate = new DateTime(2017, 7, 19), CompanyCode = "DDHX", ProductCode = "ZY6606G", ContractAmount = 60, ContractPrice = 12300 });
            context.Contracts.AddOrUpdate(new Contract { ID = 41, ContractCode = "SC-170801", ContractDate = new DateTime(2017, 8, 1), CompanyCode = "QDSC", ProductCode = "ZY6606G", ContractAmount = 15, ContractPrice = 14000 });
            context.Contracts.AddOrUpdate(new Contract { ID = 42, ContractCode = "20170808CQXH09WT", ContractDate = new DateTime(2017, 8, 8), CompanyCode = "CQXH", ProductCode = "ZY6609A", ContractAmount = 432, ContractPrice = 0, Note = "委托加工费1,800元/吨，最后用以抵扣偏钛酸货款。210吨纯钛白粉按二氧化钛含量96.5%、偏钛酸二氧化钛含量46.94%计算得出所需偏钛酸原料总量431.72吨。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 43, ContractCode = "20170809XZKJ01B", ContractDate = new DateTime(2017, 8, 9), CompanyCode = "SCXZ", ProductCode = "ZY6601C", ContractAmount = Convert.ToDecimal(0.5), ContractPrice = 34000, Note = "10%钨。实际客户：绵竹市金坤化工。EXCEL文件记录中合同编号为：20170809SCXZ01C。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 44, ContractCode = "20170814KHSM06", ContractDate = new DateTime(2017, 8, 14), CompanyCode = "KHSM", ProductCode = "ZY6606G", ContractAmount = 100, ContractPrice = 12000, Note = "现金结算。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 45, ContractCode = "20170821QDT74", ContractDate = new DateTime(2017, 8, 21), CompanyCode = "XAQY", ProductCode = "ZY6601A", ContractAmount = 98, ContractPrice = 22750 });
            context.Contracts.AddOrUpdate(new Contract { ID = 46, ContractCode = "WHEC2017-SCHT-11309", ContractDate = new DateTime(2017, 8, 23), CompanyCode = "WXHG", ProductCode = "ZY6609A", ContractAmount = 200, ContractPrice = 14900, Note = "为避免合同编号重复，此条记录由“WHEC2017-SCHT-113”修改为“WHEC2017-SCHT-11309”。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 47, ContractCode = "WHEC2017-SCHT-113", ContractDate = new DateTime(2017, 8, 23), CompanyCode = "WXHG", ProductCode = "ZY6601A", ContractAmount = 200, ContractPrice = 22750 });
            context.Contracts.AddOrUpdate(new Contract { ID = 48, ContractCode = "20170827KHSM06", ContractDate = new DateTime(2017, 8, 27), CompanyCode = "KHSM", ProductCode = "ZY6606G", ContractAmount = 100, ContractPrice = 12000 });
            context.Contracts.AddOrUpdate(new Contract { ID = 49, ContractCode = "20160811QDT38", ContractDate = new DateTime(2017, 8, 27), CompanyCode = "XAQY", ProductCode = "ZY6609A", ContractAmount = 5, ContractPrice = 9500, Note = "补签2016年的合同。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 50, ContractCode = "20170828CQXH06", ContractDate = new DateTime(2017, 8, 28), CompanyCode = "CQXH", ProductCode = "ZY6606G", ContractAmount = 300, ContractPrice = 12600 });
            context.Contracts.AddOrUpdate(new Contract { ID = 51, ContractCode = "20170912CQXH06", ContractDate = new DateTime(2017, 9, 12), CompanyCode = "CQXH", ProductCode = "ZY6606G", ContractAmount = 200, ContractPrice = 12700 });
            context.Contracts.AddOrUpdate(new Contract { ID = 52, ContractCode = "20170912HTKJ06", ContractDate = new DateTime(2017, 9, 12), CompanyCode = "HTKJ", ProductCode = "ZY6606G", ContractAmount = 200, ContractPrice = 12000 });
            context.Contracts.AddOrUpdate(new Contract { ID = 53, ContractCode = "20170918QDT87", ContractDate = new DateTime(2017, 9, 18), CompanyCode = "XAQY", ProductCode = "ZY6609A", ContractAmount = 18, ContractPrice = 15800 });
            context.Contracts.AddOrUpdate(new Contract { ID = 54, ContractCode = "20170927CQXH06", ContractDate = new DateTime(2017, 9, 27), CompanyCode = "CQXH", ProductCode = "ZY6606G", ContractAmount = 90, ContractPrice = 12700 });
            context.Contracts.AddOrUpdate(new Contract { ID = 55, ContractCode = "20171009DFTY06", ContractDate = new DateTime(2017, 10, 9), CompanyCode = "DFTY", ProductCode = "ZY6606G", ContractAmount = 500, ContractPrice = 12300 });
            context.Contracts.AddOrUpdate(new Contract { ID = 56, ContractCode = "20171010TYKJ11", ContractDate = new DateTime(2017, 10, 10), CompanyCode = "TYKJ", ProductCode = "ZY6611A", ContractAmount = 120, ContractPrice = 13250, Note = "纸版合同编号：TYCG170929-1。总量120吨，提货前2天双方书面确认价格。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 57, ContractCode = "20171016DDAD02", ContractDate = new DateTime(2017, 10, 16), CompanyCode = "DDAD", ProductCode = "ZY6602A", ContractAmount = 2, ContractPrice = 24000, Note = "纸版合同编号：ZY20171016。实发出口品。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 58, ContractCode = "20171026CQXH06", ContractDate = new DateTime(2017, 10, 26), CompanyCode = "CQXH", ProductCode = "ZY6606G", ContractAmount = 100, ContractPrice = 12700 });
            context.Contracts.AddOrUpdate(new Contract { ID = 59, ContractCode = "20171114TYKJ11", ContractDate = new DateTime(2017, 11, 14), CompanyCode = "TYKJ", ProductCode = "ZY6611A", ContractAmount = 200, ContractPrice = 13250 });
            context.Contracts.AddOrUpdate(new Contract { ID = 60, ContractCode = "20171122HBHE06", ContractDate = new DateTime(2017, 11, 22), CompanyCode = "HBHE", ProductCode = "ZY6606G", ContractAmount = 200, ContractPrice = 7100, Note = "每吨置换钛渣0.97吨。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 61, ContractCode = "20171201DDHX06", ContractDate = new DateTime(2017, 12, 1), CompanyCode = "DDHX", ProductCode = "ZY6606G", ContractAmount = 100, ContractPrice = 12000 });
            context.Contracts.AddOrUpdate(new Contract { ID = 62, ContractCode = "20171211HBHE06", ContractDate = new DateTime(2017, 12, 11), CompanyCode = "HBHE", ProductCode = "ZY6606G", ContractAmount = 200, ContractPrice = 7000, Note = "每吨置换钛渣0.97吨。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 63, ContractCode = "20171214CQXH06", ContractDate = new DateTime(2017, 12, 14), CompanyCode = "CQXH", ProductCode = "ZY6606G", ContractAmount = 100, ContractPrice = 11500 });
            context.Contracts.AddOrUpdate(new Contract { ID = 64, ContractCode = "20171220XAQY01", ContractDate = new DateTime(2017, 12, 20), CompanyCode = "XAQY", ProductCode = "ZY6601A", ContractAmount = 108, ContractPrice = 22800 });
            context.Contracts.AddOrUpdate(new Contract { ID = 65, ContractCode = "20171221XGZL01", ContractDate = new DateTime(2017, 12, 21), CompanyCode = "XGZL", ProductCode = "ZY6601A", ContractAmount = 21, ContractPrice = 3400, Note = "出口合同，合同价格为美元。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 66, ContractCode = "20171222HTKJ06", ContractDate = new DateTime(2017, 12, 22), CompanyCode = "HTKJ", ProductCode = "ZY6606G", ContractAmount = 210, ContractPrice = 11000 });
            context.Contracts.AddOrUpdate(new Contract { ID = 67, ContractCode = "20171228TYKJ11", ContractDate = new DateTime(2017, 12, 28), CompanyCode = "TYKJ", ProductCode = "ZY6611A", ContractAmount = 80, ContractPrice = 12400 });
            context.Contracts.AddOrUpdate(new Contract { ID = 68, ContractCode = "20171231HDMY11", ContractDate = new DateTime(2017, 12, 31), CompanyCode = "HDMY", ProductCode = "ZY6611A", ContractAmount = 16, ContractPrice = 12400, Note = "抵款从攀枝花汇钛科技钱先生处提走，明细账上给攀枝花汇钛科技减去16吨偏钛酸。" });
            context.Contracts.AddOrUpdate(new Contract { ID = 69, ContractCode = "20180105CQXH06", ContractDate = new DateTime(2018, 1, 5), CompanyCode = "CQXH", ProductCode = "ZY6606G", ContractAmount = 100, ContractPrice = 11500 });
            context.Contracts.AddOrUpdate(new Contract { ID = 70, ContractCode = "20180108TDHG06", ContractDate = new DateTime(2018, 1, 8), CompanyCode = "TDHG", ProductCode = "ZY6606G", ContractAmount = 500, ContractPrice = 7100, Note = "每吨置换钛渣0.97吨。" });
        }

        private void InsertDirectionRecords(CargoGo.Models.MyDBContext context)
        {
            context.Directions.AddOrUpdate(new Direction { ID = 1, DirectionCode = "BASE", DirectionDesc = "本公司" });
            context.Directions.AddOrUpdate(new Direction { ID = 2, DirectionCode = "BOTH", DirectionDesc = "进和出" });
            context.Directions.AddOrUpdate(new Direction { ID = 3, DirectionCode = "IN", DirectionDesc = "进；收入；收进发票" });
            context.Directions.AddOrUpdate(new Direction { ID = 4, DirectionCode = "OUT", DirectionDesc = "出；支出；开出发票" });
        }

        private void InsertInvoiceRecords(CargoGo.Models.MyDBContext context)
        {
            context.Invoices.AddOrUpdate(new Invoice { ID = 1, InvoiceCode = "05195936", InvoiceDate = new DateTime(2017, 7, 6), InvoiceAmount = 385000, InvoiceDirectionCode = "OUT", CompanyCode = "ZJZN" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 2, InvoiceCode = "08753223", InvoiceDate = new DateTime(2017, 8, 15), InvoiceAmount = 1344870, InvoiceDirectionCode = "OUT", CompanyCode = "SHHY" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 3, InvoiceCode = "08806039", InvoiceDate = new DateTime(2018, 1, 8), InvoiceAmount = 304400, InvoiceDirectionCode = "OUT", CompanyCode = "SDDY" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 4, InvoiceCode = "08806040", InvoiceDate = new DateTime(2018, 1, 8), InvoiceAmount = 305000, InvoiceDirectionCode = "OUT", CompanyCode = "SDDY" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 5, InvoiceCode = "08806041", InvoiceDate = new DateTime(2018, 1, 8), InvoiceAmount = 305000, InvoiceDirectionCode = "OUT", CompanyCode = "SDDY" });

            context.Invoices.AddOrUpdate(new Invoice { ID = 6, InvoiceCode = "05190509", InvoiceDate = new DateTime(2017, 4, 10), InvoiceAmount = Convert.ToDecimal(2222224.92), InvoiceDirectionCode = "OUT", CompanyCode = "DFTY" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 7, InvoiceCode = "05192767", InvoiceDate = new DateTime(2017, 4, 13), InvoiceAmount = Convert.ToDecimal(814777.66), InvoiceDirectionCode = "OUT", CompanyCode = "HTKJ" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 8, InvoiceCode = "05192769", InvoiceDate = new DateTime(2017, 4, 24), InvoiceAmount = 573300, InvoiceDirectionCode = "OUT", CompanyCode = "HNJS" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 9, InvoiceCode = "05192772", InvoiceDate = new DateTime(2017, 5, 3), InvoiceAmount = Convert.ToDecimal(1705222.34), InvoiceDirectionCode = "OUT", CompanyCode = "HTKJ" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 10, InvoiceCode = "05192774", InvoiceDate = new DateTime(2017, 5, 3), InvoiceAmount = 3000000, InvoiceDirectionCode = "OUT", CompanyCode = "CQXH" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 11, InvoiceCode = "05192776", InvoiceDate = new DateTime(2017, 5, 5), InvoiceAmount = 1953000, InvoiceDirectionCode = "OUT", CompanyCode = "WXHG" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 12, InvoiceCode = "05192777", InvoiceDate = new DateTime(2017, 5, 12), InvoiceAmount = 2205000, InvoiceDirectionCode = "OUT", CompanyCode = "WXHG" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 13, InvoiceCode = "05192778", InvoiceDate = new DateTime(2017, 5, 15), InvoiceAmount = 999000, InvoiceDirectionCode = "OUT", CompanyCode = "SHSY" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 14, InvoiceCode = "05192779", InvoiceDate = new DateTime(2017, 5, 24), InvoiceAmount = Convert.ToDecimal(1855217.73), InvoiceDirectionCode = "OUT", CompanyCode = "DFTY" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 15, InvoiceCode = "05195932", InvoiceDate = new DateTime(2017, 5, 25), InvoiceAmount = 1104000, InvoiceDirectionCode = "OUT", CompanyCode = "CQXH" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 16, InvoiceCode = "05195933", InvoiceDate = new DateTime(2017, 5, 25), InvoiceAmount = 3565462, InvoiceDirectionCode = "OUT", CompanyCode = "HBHE" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 17, InvoiceCode = "05195934", InvoiceDate = new DateTime(2017, 5, 27), InvoiceAmount = 1299600, InvoiceDirectionCode = "OUT", CompanyCode = "PGTY" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 18, InvoiceCode = "05195935", InvoiceDate = new DateTime(2017, 6, 6), InvoiceAmount = 3120000, InvoiceDirectionCode = "OUT", CompanyCode = "ZJDC" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 19, InvoiceCode = "05195937", InvoiceDate = new DateTime(2017, 6, 6), InvoiceAmount = 3864000, InvoiceDirectionCode = "OUT", CompanyCode = "CQXH" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 20, InvoiceCode = "05195938", InvoiceDate = new DateTime(2017, 6, 8), InvoiceAmount = 1168400, InvoiceDirectionCode = "OUT", CompanyCode = "SHSY" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 21, InvoiceCode = "05195939", InvoiceDate = new DateTime(2017, 6, 12), InvoiceAmount = 2404500, InvoiceDirectionCode = "OUT", CompanyCode = "WXHG" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 22, InvoiceCode = "05195941", InvoiceDate = new DateTime(2017, 6, 20), InvoiceAmount = Convert.ToDecimal(3969987.76), InvoiceDirectionCode = "OUT", CompanyCode = "DFTY" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 23, InvoiceCode = "05195942", InvoiceDate = new DateTime(2017, 7, 5), InvoiceAmount = 2404500, InvoiceDirectionCode = "OUT", CompanyCode = "WXHG" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 24, InvoiceCode = "05195943", InvoiceDate = new DateTime(2017, 7, 6), InvoiceAmount = 2144100, InvoiceDirectionCode = "OUT", CompanyCode = "WXHG" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 25, InvoiceCode = "08753213", InvoiceDate = new DateTime(2017, 7, 13), InvoiceAmount = 3039904, InvoiceDirectionCode = "OUT", CompanyCode = "CQXH" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 26, InvoiceCode = "08753215", InvoiceDate = new DateTime(2017, 7, 18), InvoiceAmount = 1100100, InvoiceDirectionCode = "OUT", CompanyCode = "PGTY" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 27, InvoiceCode = "08753216", InvoiceDate = new DateTime(2017, 7, 21), InvoiceAmount = 8100, InvoiceDirectionCode = "OUT", CompanyCode = "AHYC" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 28, InvoiceCode = "08753217", InvoiceDate = new DateTime(2017, 7, 28), InvoiceAmount = Convert.ToDecimal(2068539.82), InvoiceDirectionCode = "OUT", CompanyCode = "HTKJ" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 29, InvoiceCode = "08753218", InvoiceDate = new DateTime(2017, 8, 2), InvoiceAmount = 3006500, InvoiceDirectionCode = "OUT", CompanyCode = "WXHG" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 30, InvoiceCode = "08753219", InvoiceDate = new DateTime(2017, 8, 2), InvoiceAmount = 1350000, InvoiceDirectionCode = "OUT", CompanyCode = "SHSY" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 31, InvoiceCode = "08753220", InvoiceDate = new DateTime(2017, 8, 2), InvoiceAmount = Convert.ToDecimal(191256.59), InvoiceDirectionCode = "OUT", CompanyCode = "HTKJ" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 32, InvoiceCode = "08753222", InvoiceDate = new DateTime(2017, 8, 3), InvoiceAmount = 1400064, InvoiceDirectionCode = "OUT", CompanyCode = "CQXH" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 33, InvoiceCode = "08753224", InvoiceDate = new DateTime(2017, 8, 16), InvoiceAmount = 17000, InvoiceDirectionCode = "OUT", CompanyCode = "SCXZ" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 34, InvoiceCode = "08753225", InvoiceDate = new DateTime(2017, 8, 16), InvoiceAmount = 448000, InvoiceDirectionCode = "OUT", CompanyCode = "HBHE" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 35, InvoiceCode = "08753226", InvoiceDate = new DateTime(2017, 8, 21), InvoiceAmount = 1109682, InvoiceDirectionCode = "OUT", CompanyCode = "CQXH" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 36, InvoiceCode = "08753227", InvoiceDate = new DateTime(2017, 8, 22), InvoiceAmount = 66600, InvoiceDirectionCode = "OUT", CompanyCode = "XAYC" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 37, InvoiceCode = "08756225", InvoiceDate = new DateTime(2017, 8, 25), InvoiceAmount = Convert.ToDecimal(1168942.81), InvoiceDirectionCode = "OUT", CompanyCode = "DFTY" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 38, InvoiceCode = "08756226", InvoiceDate = new DateTime(2017, 8, 29), InvoiceAmount = 1027832, InvoiceDirectionCode = "OUT", CompanyCode = "HTKJ" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 39, InvoiceCode = "08756227", InvoiceDate = new DateTime(2017, 8, 31), InvoiceAmount = Convert.ToDecimal(493328.15), InvoiceDirectionCode = "OUT", CompanyCode = "HTKJ" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 40, InvoiceCode = "08756229", InvoiceDate = new DateTime(2017, 9, 5), InvoiceAmount = 699000, InvoiceDirectionCode = "OUT", CompanyCode = "WXHG" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 41, InvoiceCode = "08756230", InvoiceDate = new DateTime(2017, 9, 5), InvoiceAmount = 3838590, InvoiceDirectionCode = "OUT", CompanyCode = "CQXH" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 42, InvoiceCode = "08756232", InvoiceDate = new DateTime(2017, 9, 8), InvoiceAmount = 1590600, InvoiceDirectionCode = "OUT", CompanyCode = "KHSM" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 43, InvoiceCode = "08756233", InvoiceDate = new DateTime(2017, 9, 13), InvoiceAmount = 1482504, InvoiceDirectionCode = "OUT", CompanyCode = "HTKJ" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 44, InvoiceCode = "08756234", InvoiceDate = new DateTime(2017, 9, 14), InvoiceAmount = 1026550, InvoiceDirectionCode = "OUT", CompanyCode = "WXHG" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 45, InvoiceCode = "08756236", InvoiceDate = new DateTime(2017, 9, 22), InvoiceAmount = 1158240, InvoiceDirectionCode = "OUT", CompanyCode = "HTKJ" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 46, InvoiceCode = "08756237", InvoiceDate = new DateTime(2017, 10, 16), InvoiceAmount = 7867527, InvoiceDirectionCode = "OUT", CompanyCode = "CQXH" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 47, InvoiceCode = "08756238", InvoiceDate = new DateTime(2017, 10, 18), InvoiceAmount = Convert.ToDecimal(1079966.32), InvoiceDirectionCode = "OUT", CompanyCode = "DFTY" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 48, InvoiceCode = "08756239", InvoiceDate = new DateTime(2017, 10, 30), InvoiceAmount = 375150, InvoiceDirectionCode = "OUT", CompanyCode = "DDHX" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 49, InvoiceCode = "08803347", InvoiceDate = new DateTime(2017, 10, 31), InvoiceAmount = 530000, InvoiceDirectionCode = "OUT", CompanyCode = "TYKJ" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 50, InvoiceCode = "08803349", InvoiceDate = new DateTime(2017, 11, 7), InvoiceAmount = 2192500, InvoiceDirectionCode = "OUT", CompanyCode = "XAQY" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 51, InvoiceCode = "08803350", InvoiceDate = new DateTime(2017, 11, 10), InvoiceAmount = 2600000, InvoiceDirectionCode = "OUT", CompanyCode = "WXHG" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 52, InvoiceCode = "08803351", InvoiceDate = new DateTime(2017, 11, 13), InvoiceAmount = 2350080, InvoiceDirectionCode = "OUT", CompanyCode = "HTKJ" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 53, InvoiceCode = "08803354", InvoiceDate = new DateTime(2017, 11, 21), InvoiceAmount = 48000, InvoiceDirectionCode = "OUT", CompanyCode = "DDAD" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 54, InvoiceCode = "08803360", InvoiceDate = new DateTime(2017, 11, 27), InvoiceAmount = 967500, InvoiceDirectionCode = "OUT", CompanyCode = "SHSY" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 55, InvoiceCode = "08803361", InvoiceDate = new DateTime(2017, 12, 1), InvoiceAmount = 1129500, InvoiceDirectionCode = "OUT", CompanyCode = "WXHG" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 56, InvoiceCode = "08864225", InvoiceDate = new DateTime(2017, 12, 15), InvoiceAmount = 1609221, InvoiceDirectionCode = "OUT", CompanyCode = "SHHY" });
            context.Invoices.AddOrUpdate(new Invoice { ID = 57, InvoiceCode = "08806042", InvoiceDate = new DateTime(2018, 1, 8), InvoiceAmount = 8600, InvoiceDirectionCode = "OUT", CompanyCode = "XAYC" });
            
        }
    }
}
