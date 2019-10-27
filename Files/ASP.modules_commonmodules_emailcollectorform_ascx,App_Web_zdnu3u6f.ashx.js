if(typeof ASP == undefined) ASP={};
if(typeof ASP.modules_commonmodules_emailcollectorform_ascx_class == undefined) ASP.modules_commonmodules_emailcollectorform_ascx_class={};
ASP.modules_commonmodules_emailcollectorform_ascx_class = function() {};
Object.extend(ASP.modules_commonmodules_emailcollectorform_ascx_class.prototype, Object.extend(new AjaxPro.AjaxClass(), {
	AjaxRegister function(firstname, lastname, email, province, generalField1, generalField2, utm_Medium, sendEmail) {
		return this.invoke(AjaxRegister, {firstnamefirstname, lastnamelastname, emailemail, provinceprovince, generalField1generalField1, generalField2generalField2, utm_Mediumutm_Medium, sendEmailsendEmail}, this.AjaxRegister.getArguments().slice(8));
	},
	url 'ajaxproASP.modules_commonmodules_emailcollectorform_ascx,App_Web_zdnu3u6f.ashx'
}));
ASP.modules_commonmodules_emailcollectorform_ascx = new ASP.modules_commonmodules_emailcollectorform_ascx_class();
