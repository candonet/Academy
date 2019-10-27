function alertObject(o) {
	seen = [];
	alert(JSON.stringify(o, function(key, val) {
		if (typeof val == "object") {
			if (seen.indexOf(val) >= 0) return
			seen.push(val)
		}
		return val
	}));
}
Array.prototype.last = function() {
	if (this.length == 0) return null;
	return this[this.length - 1];
}
if (!Array.prototype.indexOf) {
	Array.prototype.indexOf = function(obj, fromIndex) {
		if (fromIndex == null) {
			fromIndex = 0;
		} else if (fromIndex < 0) {
			fromIndex = Math.max(0, this.length + fromIndex);
		}
		for (var i = fromIndex, j = this.length; i < j; i++) {
			if (this[i] === obj)
				return i;
		}
		return -1;
	};
}
Array.prototype.removeAt = function(i) {
	if (i < 0 || i > this.length - 1)
		return;
	this.splice(i, 1);
}
Array.prototype.remove = function(o) { this.removeAt(this.indexOf(o)); }
Array.prototype.find = function(o) { return (this.indexOf(o) != -1); }
Array.prototype.add = Array.prototype.push;

//End Array
window.lcEnFa = {
	en: 'qwertyuiop\[\]\\asdfghjkl;\'zxcvbnm,',
	fa: 'ضصثقفغعهخحجچپشسیبلاتنمکگظطزرذدئو'
}
String.prototype.initEnFa = function() {
	if (String.prototype.enToFa) return;
	window.lcEnFa.enRegex = new RegExp('[' + (window.lcEnFa.en.replace('\[', '\\\[').replace('\]', '\\\]').replace('\\', '\\\\')) + ']', 'g');
	window.lcEnFa.faRegex = new RegExp('[' + window.lcEnFa.fa + ']', 'g');
	window.lcEnFa.enToFa = {}
	window.lcEnFa.faToEn = {};
	for (var i = 0; i < window.lcEnFa.en.length; i++) {
		window.lcEnFa.enToFa[window.lcEnFa.en[i]] = window.lcEnFa.fa[i];
		window.lcEnFa.faToEn[window.lcEnFa.fa[i]] = window.lcEnFa.en[i];
	}
}
String.prototype.toEn = function() {
	String.prototype.initEnFa();
	return this.replace(window.lcEnFa.faRegex, function(w) { return window.lcEnFa.faToEn[w] });
}
String.prototype.toFa = function() {
	String.prototype.initEnFa();
	return this.replace(window.lcEnFa.enRegex, function(w) { return window.lcEnFa.enToFa[w] });
}
String.prototype.toAsciiDigits = function() {
	return this.replace(/[٠١٢٣٤٥٦٧٨٩]/g, function(w) {
		return { '٠': '0', '١': '1', '٢': '2', '٣': '3', '٤': '4', '٥': '5', '٦': '6', '٧': '7', '٨': '8', '٩': '9'}[w];
	});
}
String.prototype.toPersianDigits = function() {
	return this.replace(/[0-9]/g, function(w) {
		return '٠١٢٣٤٥٦٧٨٩'[w]
	});
}
$(document).ready($('[num=fa]:not(:has(*)), [num=fa] :not(:has(*))').each(function(){
		if(this.tagName && this.tagName.toLowerCase() == 'style')
			return;
		$(this).text($(this).text().toPersianDigits());
}));
String.prototype.toNumber = function() {
	return this.replace(/\D/g, '');
}
String.prototype.toPrice = function() {
	var res = this.toNumber();
	return res.replace(/\B(?=(\d{3})+(?!\d))/g, ',');
}
String.prototype.toSSN = function() {
	var res = this.toNumber();
	if (res.length <= 3)
		return res;
	if (res.length <= 9)
		return res.replace(/^(\d{3})(\d{1})/g, '$1-$2');
	if (res.length >= 10)
		return res.replace(/^(\d{3})(\d{6})(\d)(\d*)/g, '$1-$2-$3');
}
String.prototype.toPostalCode = function() {
	var res = this.toNumber();
	if (res.length <= 5)
		return res;
	else
		return res.replace(/^(\d{5})(\d{1,5})(\d*)/g, '$1-$2');
}
String.prototype.hasUnicode = function() {
	for (var i = 0; i < this.length; i++)
		if (this.charCodeAt(i) > 255)
		return true;

	return false;
}
String.prototype.format = function(format) {
	format = format || '';
	switch (format.toLowerCase()) {
		case 'number': return this.toNumber();
		case 'price': return this.toPrice();
		case 'ssn': return this.toSSN();
		case 'postalcode': return this.toPostalCode();
	}
	return this;
}
String.prototype.transform = function(metaData, data) {
	if (!metaData) {
		var tags = this.match(/#([^#])+#/gi);
		if (!tags) tags = [];
		metaData = [];
		for (var i = 0; i < tags.length; i++)
			metaData.push({
				tag: new RegExp(tags[i], 'g'),
				name: tags[i].replace(/#/g, '')
			});
	}
	var output = '';
	if (!$.isArray(data)) data = [].concat(data);
	for (var i = 0; i < data.length; i++) {
		if (!data[i])
			continue;
		var recordOutput = this;
		for (var j = 0; j < metaData.length; j++) {
			var prop = data[i][metaData[j].name];
			recordOutput = recordOutput.replace(metaData[j].tag, prop);
			recordOutput = recordOutput.replace(/#enter#/gi, '\n');
		}
		output += recordOutput;
	}
	return output;
}
/* End String */
jQuery.fn._lcShow = jQuery.fn.show;
jQuery.fn.show = function(speed, easing, callback) {
	this.removeClass('LocoHide');
	this._lcShow(speed, easing, callback);
};
//jQuery.fn._lcHtml = jQuery.fn.html;
//jQuery.fn.html = function(value){
//	if(value) return this._lcHtml(value);
//	return (this.exists())? this._lcHtml() : '';
//}
jQuery.fn.scrollIntoView = function() { this.each(function() { this.scrollIntoView() }) }
jQuery.fn.lc_scrollToEnd = function(){$(this).scrollTop($(this).prop("scrollHeight"))}
jQuery.fn.flashClass = function(className, time) {
	if (!time) time = 1500;
	this.addClass(className);
	var self = this;
	setTimeout(function() { self.removeClass(className) }, time);
}
jQuery.fn.contains = function(el) { return (this.find($(el)).length > 0); }
jQuery.fn.lc_findElement = function(elName){
	return this.find('[data-fm-el=' + elName +'],[fm-el=' + elName +']');
}
jQuery.fn.lc_changeAttr =  function(oldAttr, newAttr){
	this.attr(newAttr, this.attr(oldAttr));
	this.removeAttr(oldAttr);
}
jQuery.fn.lc_validate = function(validationGroup){return lc$.Validation.validate(validationGroup, this)}
jQuery.fn.lc_clearValidate = function(validationGroup){return lc$.Validation.clear(validationGroup, this)}
jQuery.fn.equals = function(el) { 
	if (!el || this.length != el.length) {
		return false;
	}
	for (var i = 0; i < this.length; ++i) {
		if (this[i] !== el[i]) {
			return false;
		}
	}
	return true;
}

jQuery.fn.insertAt = function(el, i) {
	if (typeof i === 'undefined' || i >= this.children().length) this.append($(el));
	else this.each(function() {
		$(this).children().eq(i).before($(el))
	});
}
jQuery.fn.addOption = function(value, text, i) {
	text = text || value;
	var o = $("<option ></option>");
	o.attr('value', value);
	o.text(text);
	this.insertAt(o, i)
}
jQuery.fn.enable = function() { this.removeProp('disabled'); this.removeAttr('disabled'); return this; }
jQuery.fn.disable = function() { this.prop('disabled', true); this.attr('disabled', 'disabled'); return this; }
jQuery.fn.center = function() {
	this.css({
		"position": "fixed",
		"top": "50%",
		"left": "50%",
		"marginTop": "-" + $(this).outerHeight() / 2 + "px",
		"marginLeft": "-" + $(this).outerWidth() / 2 + "px"
	});
	return this;
} //end center
jQuery.fn.viewOffset = function() {
	var bounds = this.offset();
	bounds.right = bounds.left + this.outerWidth();
	bounds.bottom = bounds.top + this.outerHeight();

	var win = $(window);
	var viewport = {
		top: win.scrollTop(),
		left: win.scrollLeft()
	}
	viewport.right = viewport.left + win.width();
	viewport.bottom = viewport.top + win.height();
	return {
		left: bounds.left - viewport.left,
		top: bounds.top - viewport.top,
		right: viewport.right - bounds.right,
		bottom: viewport.bottom - bounds.bottom
	}
}
jQuery.fn.isInView = function() {
	var viewOffset = this.viewOffset();
	return (
		viewOffset.left >= 0 &&
		viewOffset.top >= 0 &&
		viewOffset.right >= 0 &&
		viewOffset.bottom >= 0
	);
}
jQuery.fn.getValue = function(valueType, ignoreFormat) {
	var val = this.val();
	if (!val)
		val = '';
	if (val.toAsciiDigits)
		val = val.toAsciiDigits();
	if (!ignoreFormat) {
		var format = this.attr('lc-format');
		switch (format) {
			case 'number':
			case 'price':
				return val.toNumber();
		}
	}

	switch (this.attr('type')) {
		case 'checkbox':
			return this.prop('checked');
		case 'radiolist':
			return this.find('input:checked').val();
		case 'checklist':
			var checked = this.find('input:checked');
			var value = '';
			for (var i = 0; i < checked.length; i++)
				value += $(checked[i]).val() + ',';
			return value;
		case 'multifieldrepeater':
			var multiFieldRepeater = this.data('multifieldrepeater');
			return multiFieldRepeater.getValues();
		case 'customfieldscontrol':
			var customFieldsControl = this.data('customfieldscontrol');
			return customFieldsControl.getValues();
		case 'hierarchy':
			var selects = this.find('select');
			var value = '';
			for (var i = 0; i < selects.length; i++)
				value += $(selects[i]).val() + ',';
			return value;
	}

	if (!val || val == '') {
		switch (valueType) {
			case 'string': return '';
			case 'int': return 0;
			case 'bool': return false;
			case 'guid': return '00000000-0000-0000-0000-000000000000';
			default: return '';
		}
	}
	else
		return val;
} //end getValue
jQuery.fn.setValue = function(value, preserveSelectionPos) {
	var format = this.attr('lc-format');
	if (format && format != '') {
		value = value + '';
		value = value.format(format);
	}

	if (this.is('select')) {
		this.val(value);
		if (this.prop('selectedIndex') < 0)
			this.prop('selectedIndex', 0);
	}
	else {
		switch (this.attr('type')) {
			case 'checkbox':
				this.prop('checked', value + '' === 'true');
				break;
			case 'radiolist':
				this.find('input[value=' + value + ']').prop('checked', true);
				break;
			case 'checklist':
				var values = value.split(',');
				this.find('input:checkbox').setValue(false);
				for (var i = 0; i < values.length; i++) {
					this.find('input[value=' + values[i] + ']').prop('checked', true);
				}
				break;
			case 'multifieldrepeater':
				var multiFieldRepeater = this.data('multifieldrepeater');
				multiFieldRepeater.setValues(value);
				break;
			case 'customfieldscontrol':
				var customFieldsControl = this.data('customfieldscontrol');
				customFieldsControl.setValues(value);
				break;
			case 'hierarchy':
				var values = value.split(',');
				var container = this.find('[hierarchySelectorContainer]');
				if (container.data('hierarchySelector')) {
					container.data('hierarchySelector').setSelectedValues(values);
				}
				break;
			default:
				if (preserveSelectionPos && this.val().length == value.length) {
					var selStart = this[0].selectionStart;
					var selEnd = this[0].selectionEnd;
					this.val(value);
					this[0].setSelectionRange(selStart, selEnd);
				}
				else
					this.val(value);
		}
	}
	this.trigger('change');
}       //end setValue
$.fn.insertAtCaret = function(text) {
	return this.each(function() {
		if (document.selection && this.tagName == 'TEXTAREA') {
			//IE textarea support
			this.focus();
			sel = document.selection.createRange();
			sel.text = text;
			this.focus();
		} else if (this.selectionStart || this.selectionStart == '0') {
			//MOZILLA/NETSCAPE support
			startPos = this.selectionStart;
			endPos = this.selectionEnd;
			scrollTop = this.scrollTop;
			this.value = this.value.substring(0, startPos) + text + this.value.substring(endPos, this.value.length);
			this.focus();
			this.selectionStart = startPos + text.length;
			this.selectionEnd = startPos + text.length;
			this.scrollTop = scrollTop;
		} else {
			// IE input[type=text] and other browsers
			this.value += text;
			this.focus();
			this.value = this.value;    // forces cursor to end
		}
	});
};
//end insertAtCaret
jQuery.fn.format = function(format) {
	if (!this.exists()) return;
	if (!format) format = this.attr('lc-format');
	this.setValue(this.val().format(format), true);
}
$(document).ready(function() { $('[lc-format]').each(function() { $(this).format() }) });
$(document.body).on('keyup', '[lc-format]', function(e) { $(e.target).format() });
//end format
$(document.body).on('keypress', '[defaultelement]',
	function(e) {
		if (!e || e.keyCode != 13) return true;
		var el = $(e.target);
		if (!el.hasAttr('defaultelement'))
			el = el.closest('[defaultelement]');
		var target = $('#' + el.attr('defaultelement'));
		if (!target.exists()) return true;
		e.stopPropagation();
		e.preventDefault();
		target.trigger('click');
		return false;
	});
//end defaultelement
$(document.body).on('change', 'input[lc-toggletarget]:checkbox', function(){
	var el = $(this);
	var checked = el.prop('checked');
	var targetSelector = el.attr('lc-toggletarget');
	if (targetSelector[0] == '!'){
		targetSelector = targetSelector.substring(1, targetSelector.length);
		checked = !checked;
	}
	
	$(targetSelector).toggle(checked);
});
//end toggleTarget
$(document.body).on('keydown', '[data-lc-change-delay]', function(e) {
	var target = $(e.target);
	var timeout = target.data('lc-change-delay-timeout');
	if (timeout)
		clearTimeout(timeout);
	if (e.keyCode == 10 || e.keyCode == 13) {
		e.preventDefault();
		target.trigger('lc-delaychange');
		return;
	}
	var delay = parseInt(target.attr('data-lc-change-delay'));
	if (isNaN(delay) || delay == -1)
		delay = 800;
	timeout = setTimeout(function() {
		target.trigger('lc-delaychange')
	}, delay);
	target.data('lc-change-delay-timeout', timeout);
});
//end lc-delay-change
jQuery.fn.shuffle = function() {
	this.children().sort(function() {
		return (Math.round(Math.random()) - 0.5)
	}).detach().appendTo(this);
} //end shuffle
jQuery.fn.verticalSort = function(colCount) {
	var container = this;
	var count = $(container).children().size();
	var colSize = count / colCount;
	var cols = [];
	for (i = 0; i < colSize; i++) {
		var col = $('<div class="container-col"></div>');
		for (j = 0; j < colCount; j++) {
			col.append($(container).children().eq(0));
		}
		cols.push(col);
	}
	$(container).empty();
	for (var i = 0; i < cols.length; i++)
		$(container).append(cols[i]);
	$(container).append($('<div class="clr"></div>'));
}
jQuery.fn.exists = function() { return this.length > 0; }
jQuery.fn.hasAttr = function(name) {
	var attr = this.attr(name);
	return (typeof attr !== 'undefined' && attr !== false)
}
jQuery.fn.lc_dataBind = function(data, hideEmpty) {
	var container = this;
	var els = $(container).find('[lc-bind-el]');
	els.each(function() {
		var el = $(this);
		var propName = el.attr('lc-bind-el');
		var prop = lc$.getMember(data, propName);
		if (hideEmpty && (!prop || prop == '')) {
			el.hide();
			return;
		}
		el.show();
		var valEl = el.find('[lc-bind-val]');

		var template = el.find('[lc-bind-template]').html();
		if (template && template != '') {
			prop = template.transform(null, prop);
		}
		if (valEl.exists())
			valEl.html(prop);
		else
			el.html(prop);
	});
	var inputs = $(container).find('[lc-bind-inp]');
	inputs.each(function() {
		var input = $(this);
		var propName = input.attr('lc-bind-inp');
		var prop = lc$.getMember(data, propName);
		input.setValue(prop);
	});
}
jQuery.fn.lc_getData = function() {
	var container = this;
	var data = {};
	var inputs = $(container).find('[lc-get-el]');
	inputs.each(function() {
		var input = $(this);
		var propName = input.attr('lc-get-el');
		lc$.setMember(data, propName, input.getValue());
	});
	return data;
}
jQuery.fn.lc_onScrollTop = function(callBack, threshold){
	if(this.length == 0) return;
	if(!threshold) threshold = 20;
	var self = this;
	this.on('scroll', function(){
		if(self.scrollTop <= threshold)
			callBack();
	});
}
jQuery.fn.lc_onScrollBottom = function(callBack, threshold){
	if(this.length == 0) return;
	if(!threshold) threshold = 20;
	var self = this;
	this.on('scroll', function(){
		var scrollBottom = self[0].scrollHeight - self.height() - self.scrollTop();
		if( scrollBottom <= threshold)
			callBack();
	});
}
//End JQuery
$(document).ready(function() {
	$('[lcAppendTo]').each(function() {
		var el = $(this);
		el.appendTo($(el.attr('lcAppendTo')));
	});
});		
//end lcappendto
lc$.getMember = function(o, name) {
	var res = o;
	name = name.split('.');
	for (var i = 0; i < name.length; i++) {
		res = res[name[i]];
		if (!res)
			return null;
	}
	return res;
}
lc$.setMember = function(o, name, data) {
	var tempO = o;
	name = name.split('.');
	for (var i = 0; i < name.length; i++) {
		if (i == name.length - 1) {
			tempO[name[i]] = data;
		}
		else {
			if (!tempO[name[i]])
				tempO[name[i]] = {};
			tempO = tempO[name[i]];
		}
	}
	return o;
}

lc$.Validation = {
	getFormatRegEx: function(format){
		switch (format) {
			case '':
			case 'text':
			case 'password':
			case 'checkbox':
				return null;
			case 'email':
				return /^(?!www\.).+([\+a-zA-Z0-9_.-])+@([a-zA-Z0-9_.-])+\.([a-zA-Z])+([a-zA-Z])+$/;
			case 'phone':
				return /^(\+)?[\d-]{4,}\d$/;
			case 'mobile':
				return /^0?9\d{9}|\+?98(?:\(\d{3}\))?\d{7,}$/;
			case 'url':
				return /^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?(\?.*)?(#.*)?$/;
			case 'integer':
				return /^(\+|-)?\d+$/;
			case 'decimal':
				return /^[0-9]*[\.]?[0-9]+$/;
		}
		return new RegExp(format);
	},
	_convertOldAttr: function(container){
		container.find('[validationgroup]').each(function(){$(this).lc_changeAttr('validationgroup', 'data-val-group')});
		container.find('[locovalidationgroup]').each(function(){$(this).lc_changeAttr('locovalidationgroup', 'data-val-group')});
		container.find('[requiredmessage]').each(function(){$(this).lc_changeAttr('requiredmessage', 'data-val-req-msg')});
		container.find('[formatmessage]').each(function(){$(this).lc_changeAttr('formatmessage', 'data-val-format-msg')});
		container.find('[validationpattern]').each(function(){
			var el = $(this);
			if(el.attr('validationpattern') != '')
				el.lc_changeAttr('validationpattern', 'data-val-format')
		});
		container.find('[locotype]').each(function(){$(this).lc_changeAttr('locotype', 'data-val-format')});
		container.find('[type]').each(function(){
			var el = $(this);
			if(el.hasAttr('data-val-group') && !el.hasAttr('data-val-format'))
				el.attr('data-val-format', el.attr('type'));
		});
	},
	validate: function(validationGroup, container) {
		container = $(container);
		if (!container.exists())
			container = $(document.body);
		lc$.Validation._convertOldAttr(container);
		var firstInvalid = null;
		var els = container.find('[data-val-group=' + validationGroup + ']');
		els.each(function() {
			var el = $(this);
			var requiredMessage = el.attr('data-val-req-msg');
			var formatMessage = el.attr('data-val-format-msg');
			var formatRegEx = lc$.Validation.getFormatRegEx(el.attr('data-val-format'));
			
			var validationElement = el.data('validationElement');
			if (!validationElement && (requiredMessage || formatMessage)) {
				validationElement = $('<span class="val-msg" />')
				el.before(validationElement);
				el.data('validationElement', validationElement);
				if (requiredMessage)
					validationElement.append('<span class="val-req" >' + requiredMessage + '</span>');
				if (formatMessage)
					validationElement.append('<span class="val-format" >' + formatMessage + '</span>');
			}
			if (!validationElement)
				return;
			el.removeClass('invalid-req-input');
			validationElement.removeClass('invalid-req-msg');
			el.removeClass('invalid-format-input');
			validationElement.removeClass('invalid-format-msg');
			
			var value = el.getValue();
			if (value == '' && requiredMessage) {
				if (!firstInvalid)
					firstInvalid = el;
				el.addClass('invalid-req-input');
				validationElement.addClass('invalid-req-msg');
				return;
			}

			if ( value != '' && formatRegEx && formatMessage && !formatRegEx.test(value)) {
				if (!firstInvalid)
					firstInvalid = el;
				el.addClass('invalid-format-input');
				validationElement.addClass('invalid-format-msg');
			}
		});//end each()
		
		if (firstInvalid) {
			firstInvalid.scrollIntoView(false);
			return false;
		}
		return true;
	},
	clear: function(validationGroup, container) {
		container = $(container);
		if (!container.exists())
			container = $(document.body);
		var els = container.find('[data-val-group=' + validationGroup + ']');
		els.each(function() {
			var el = $(this);
			var validationElement = $(el.data('validationElement'));
			el.removeClass('invalid-req-input invalid-format-input');
			validationElement.removeClass('invalid-req-msg invalid-format-msg');
		})
	}
};
//end lc$.Validation
lc$.LiveDropdown = function(o) {
	this.dropDown = null;
	this.ajaxClass = null;
	$.extend(this, o);
	if (!this.dropDown.exists())
		return;

	this.clientId = this.dropDown.prop('id');
	lc$.LiveDropdown[this.clientId] = this;

	this.objectName = 'lc$.LiveDropdown.' + this.clientId;
	this.ajaxMethod = this.dropDown.attr('ajaxmethod'); ;
	this.ajaxCreateNew = this.dropDown.attr('ajaxcreatenew'); ;
	this.ajaxRefresh = this.dropDown.attr('ajaxrefresh'); ;
	this.selectCaption = this.dropDown.attr('selectcaption');
	this.createNewCaption = this.dropDown.attr('createnewcaption');

	this.items = [];

	var self = this;
	this.dropDown.on('change', function() { if (self.dropDown.getValue() == 'new') self.createNew(); });
	this.dropDown.on('lc-refresh', function() { self.refresh(); });
	$(document).on(this.ajaxRefresh, function(e, selectedValue) { self.refresh(selectedValue); });
	
	this.refresh();
}
lc$.LiveDropdown.prototype = {
	createNew: function() {
		this.dropDown.trigger('lc-new');
		$(document).trigger(this.ajaxCreateNew);
		this.dropDown.addClass('LocoLoading');
	},
	refresh: function(selectedValue) {
		this.selectedValue = selectedValue;
		lc$.Ajax.startAjaxProgress();
		if (this.ajaxClass && (typeof this.ajaxClass[this.ajaxMethod] === 'function'))
			this.ajaxClass[this.ajaxMethod](this.objectName, lc$.Ajax.callback);
	},
	refreshCallback: function(items) {
		this.items = items;
		this.dropDown.empty();
		this.dropDown.addOption('', this.selectCaption);

		for (var i = 0; i < this.items.length; i++) {
			this.dropDown.addOption(this.items[i].Key, this.items[i].Value);
		}
		this.dropDown.addOption('new', this.createNewCaption);
		this.dropDown.setValue(this.selectedValue);			
		this.dropDown.removeClass('LocoLoading');
	},
	getSelectedKey: function() {
		return this.dropDown.getValue();
	},
	setSelectedKey: function(key) {
		this.dropDown.setValue(key);
	}
}
lc$.LiveDropdown.create = function(els, ajaxClass) {
	$(els).each(function() {
		var dropDown = $(this);
		new lc$.LiveDropdown({ dropDown: dropDown, ajaxClass: ajaxClass });
	});
}
//end lc$.LiveDropdown

lc$.TargetOpener = {
	_stack: [],
	_dataDic: {},
	_getData: function(o) {
		var id = 'lcto_' + lc$.uid();
		var data = {
			id: id,
			opener: $('<div/>'),
			target: $('<div/>'),
			dontmove: true,
			onOpen: null,
			onClose: null,
			targetPos: '',
			targetLeft: 0,
			targetTop: 0,
			openMode: 'click'
		}
		for (var p in o)
			if (o[p] == null)
			delete o[p];
		$.extend(data, o);
		lc$.TargetOpener._dataDic[id] = data;
		data.target.attr('lc-targetid', id);
		data.target.find('[lc-closetarget=true]').attr('lc-closetargetid', id);
		return data;
	},
	attach: function(o) {
		var data = lc$.TargetOpener._getData(o);
		if (data.opener.attr('lc-targetopenerid'))
			return;
		data.target.attr('lc-targetid', data.id);
		data.target.find('[lc-closetarget=true]').attr('lc-closetargetid', data.id);
		data.opener.removeAttr('opentarget lcopentarget');
		data.opener.attr('lc-openerid', data.id);
	},
	detach: function(opener) {
		opener = $(opener);
		opener.removeAttr('lc-openerid');
	},
	_attach: function(e) {
		e.stopPropagation();
		var opener = $(e.target);
		if (!opener.hasAttr('lcopentarget') && !opener.hasAttr('opentarget'))
			opener = opener.closest('[opentarget],[lcopentarget]');
		var target = null;
		if (opener.hasAttr('lcopentarget'))
			target = $(opener.attr('lcopentarget'));
		else
			target = $('#' + opener.attr('opentarget'));

		var data = {
			opener: opener,
			target: target,
			dontmove: (opener.attr('targetdontmove') ? opener.attr('targetdontmove') == 'true' : false),
			onOpen: opener.attr('onopentarget'),
			onClose: opener.attr('onclosetarget'),
			targetPos: opener.attr('targetposition'),
			targetLeft: opener.attr('targetleft'),
			targetTop: opener.attr('targettop'),
			openMode: opener.attr('openmode')
		}
		lc$.TargetOpener.attach(data);
		lc$.TargetOpener.open(data, e);
		return false;
	},
	open: function(data, e) {
		if (data.target && data.target.attr('lc-targetid'))
			data = lc$.TargetOpener._dataDic[data.target.attr('lc-targetid')];
		else
			data = lc$.TargetOpener._getData(data);

		var current = lc$.TargetOpener._stack.last();
		if (current) {
			if (current.id == data.id) {
				lc$.TargetOpener._close(e, data);
				return false;
			}
			if (!current.target.contains(data.opener))
				lc$.TargetOpener._close(e, data);
		}
		lc$.TargetOpener._stack.push(data);
		data.opener.addClass('LocoSelect');
		lc$.TargetOpener._setPos(e);
		data.target.show();
		data.target.find('input:visible,select:visible,textarea:visible').eq(0).focus();
		lc$.exec(data.onOpen);
	},
	_open: function(e, e2) {
		if (e2) e = e2;
		e.stopImmediatePropagation();

		var opener = $(e.target);
		if (!opener.hasAttr('lc-openerid'))
			opener = opener.closest('[lc-openerid]');
		var data = lc$.TargetOpener._dataDic[opener.attr('lc-openerid')];
		if (!data) return;
		lc$.TargetOpener.open(data, e);
		return false;
	},
	close: function() {
		lc$.TargetOpener._close();
	},
	_close: function(e, data) {
		var current = lc$.TargetOpener._stack.last();
		if (!current)
			return;
		if (e) {
			var closeBtn = $(e.target).closest('[lc-closetargetid]');
			if (closeBtn.exists()) {
				data = lc$.TargetOpener._dataDic[closeBtn.attr('lc-closetargetid')];
			}
			else {
				var target = $(e.target).closest('[lc-targetid]');
				if (target.exists()){
					if (current.id == target.attr('lc-targetid'))
						return;
				}
			}
		}
		var clickedElement = (data) ? data.opener : ((e) ? $(e.target): null);
		if(current.target.contains(clickedElement))
			return;
		//don't close if the clicked element is in dialog box and the target element is in the meain page
		if(clickedElement && lc$.Dialog.boxElement && !lc$.Dialog.boxElement.contains(current.target) &&
				(	lc$.Dialog.maskElement.get(0) === clickedElement.get(0) ||
					lc$.Dialog.boxElement.get(0) === clickedElement.get(0) ||
					lc$.Dialog.boxElement.contains(clickedElement) 
				)
			)
			return; 

		var last = lc$.TargetOpener._stack.pop();
		if (!last) return;
		last.target.hide();
		last.opener.removeClass('LocoSelect');
		lc$.exec(last.onClose);
		if (data && last.id == data.id) {
			return;
		}
		lc$.TargetOpener._close(e, data);
	},
	_move: function(coord) {
		var data = lc$.TargetOpener._stack.last();
		if (!data.dontmove && !data.target.attr('targetMoved')) {
			data.opener.after(data.target);
			data.target.css('position', 'absolute');
			data.target.attr('targetMoved', 'true');
		}
		data.target.show();
		data.target.offset(coord);
	},
	_setPos: function(e) {
		var data = lc$.TargetOpener._stack.last();
		if (!data.targetPos) data.targetPos = '';
		
		switch (data.targetPos.toLowerCase()) {
			case 'center':
				data.target.show();
				data.target.center();
				break;
			case 'opener':
				lc$.TargetOpener._move({
					left: data.targetLeft ? data.opener.offset().left + (1 * data.targetLeft) : null,
					top: data.targetTop ? data.opener.offset().top + (1 * data.targetTop) : null
				});
				break;
			case 'mouse':
				lc$.TargetOpener._move({
					left: data.targetLeft ? e.clientX + (1 * data.targetLeft) : null,
					top: data.targetTop ? e.clientY + (1 * data.targetTop) + $(document).scrollTop() : null
				});
				break;
			case 'inview-top':
				data.target.show();
				lc$.TargetOpener._move({
					left: data.opener.offset().left + (data.opener.outerWidth() / 2) - (data.target.outerWidth() / 2),
					top: data.opener.offset().top - data.target.outerHeight()
				});
				data.target.removeClass('lcopener-under');
				data.target.addClass('lcopener-top');
				if (!data.target.isInView()) {
					var view = data.target.viewOffset();
					var newPos = { left: view.left, top: view.top }
					if (view.top < 0)
						newPos.top = data.opener.offset().top + data.opener.outerHeight();
					if (view.left < 0)
						newPos.left += (-view.left);
					else if (view.right < 0)
						newPos.left += view.right;
					lc$.TargetOpener._move(newPos);
					data.target.removeClass('lcopener-top');
					data.target.addClass('lcopener-under');
				}
				break;
			case 'inview-under':
				data.target.show();
				lc$.TargetOpener._move({
					left: data.opener.offset().left + (data.opener.outerWidth() / 2) - (data.target.outerWidth() / 2),
					top: data.opener.offset().top + data.opener.outerHeight()
				});
				data.target.removeClass('lcopener-top');
				data.target.addClass('lcopener-under');
				if (!data.target.isInView()) {
					var view = data.target.viewOffset();
					var newPos = { left: view.left, top: view.top }
					if (view.bottom < 0)
						newPos.top = data.opener.offset().top - data.target.outerHeight();
					if (view.left < 0)
						newPos.left += (-view.left);
					else if (view.right < 0)
						newPos.left += view.right;
					lc$.TargetOpener._move(newPos);
					data.target.removeClass('lcopener-under');
					data.target.addClass('lcopener-top');
				}
				break;
			default:
				break;
		}
	},
	convert: function(el) { console.log('Loco.TargetOpener.convert() is deprecated') }
}

$(document).on('click', '[opentarget],[lcopentarget]', lc$.TargetOpener._attach);
$(document).on('click', '[lc-openerid]', lc$.TargetOpener._open);
$(document).on('click', lc$.TargetOpener._close);
//end lc$.TargetOpener
lc$.Events = {
	attach: function(event, key, fn) {
		$(document).on(event + '.' + key, fn);
	},
	detach: function(event, key) {
		$(document).off(event + '.' + key);
	},
	dispatch: function(event, args) {
		$(document).trigger(event, args);
	}
};
//end lc$.Events
lc$.Dialog = {
	init: function() {
		if (this.isInit)
			return;
		this.isInit = true;

		$(document.forms).append($(
			"<div class='dlg-mask' style='display:none' />" +
			"<div class='dlg-box' style='display:none' >" +
			"	<div class='dlg-title' style='display:none' />" +
			"	<div class='dlg-close' style='display:none' />" +
			"	<div class='dlg-content' />" +
			"	<div class='dlg-buttons' style='display:none'><div class='dlg-ok' style='display:none' /><div class='dlg-cancel' style='display:none' /></div>" +
			"</div>"
		));
		this.maskElement = $('.dlg-mask');
		this.boxElement = $('.dlg-box');

		this.titleElement = this.boxElement.find('.dlg-title');
		lc$.Drag.attach(this.titleElement, this.boxElement);
		this.closeElement = this.boxElement.find('.dlg-close');
		this.closeElement.on('click', function() { lc$.Dialog.hide(); });
		this.contentElement = this.boxElement.find('.dlg-content');
		this.contentElement.on('click', '[data-lc-dlg-close]', function(e){
			e.stopPropagation();
			lc$.Dialog.hide();
		});

		this.buttonsElement = this.boxElement.find('.dlg-buttons');
		this.okElement = this.boxElement.find('.dlg-ok');
		this.okElement.on('click', function() { lc$.Dialog.hide(true); });
		this.cancelElement = this.boxElement.find('.dlg-cancel');
		this.cancelElement.on('click', function() { lc$.Dialog.hide(false); });

	},
	reset: function() {
		this.boxElement.width('');
		this.boxElement.height('');
		lc$.TargetOpener.preventClose = false;
	},
	show: function(options) {
		this.options = {
			title: null,
			width: null,
			height: null,
			className: null,
			hasClose: false,
			hasOk: false,
			hasCancel: false,
			html: '',
			okCallback: null,
			cancelCallback: null,
			params: null,
			preventTargetOpenerClose: true
		};
		$.extend(this.options, options);
		this.init();

		this.boxElement.removeClass();		
		this.boxElement.addClass('dlg-box');
		this.boxElement.addClass(this.options.className);

		if (this.options.width)
			this.boxElement.width(this.options.width);
		if (this.options.height)
			this.boxElement.height(this.options.height);

		if (this.options.hasClose) this.closeElement.show(); else this.closeElement.hide();
		if (this.options.title) this.titleElement.show(); else this.titleElement.hide();
		this.titleElement.empty();
		this.titleElement.append(this.options.title);

		if (this.options.hasOk || this.options.hasCancel) this.buttonsElement.show(); else this.buttonsElement.hide();
		if (this.options.hasOk) this.okElement.show(); else this.okElement.hide();
		if (this.options.hasCancel) this.cancelElement.show(); else this.cancelElement.hide();

		if (typeof this.options.html === 'string')
			this.options.html = '<span>' + this.options.html + '</span>';
		this.options.html = $(this.options.html);
		this.elementParent = this.options.html.parent();
		this.contentElement.append(this.options.html);
		this.options.html.show();

		this.boxElement.show();
		this.maskElement.show();

		this.boxElement.center();
		lc$.TargetOpener.preventClose = this.options.preventTargetOpenerClose;
	},
	hide: function(isOk) {
		this.init();
		this.boxElement.hide();
		this.maskElement.hide();
		if (this.elementParent && this.elementParent.exists()) {
			this.elementParent.append(this.options.html);
			this.options.html.hide();
		}

		this.contentElement.empty();

		if (isOk && lc$.Dialog.options && lc$.Dialog.options.okCallback)
			lc$.Dialog.options.okCallback(lc$.Dialog.options.params);
		if (!isOk && lc$.Dialog.options && lc$.Dialog.options.cancelCallback != null)
			lc$.Dialog.options.cancelCallback(lc$.Dialog.options.params);
		lc$.Dialog.reset();
	},
	alert: function(message, className) {
		this.show({ title: 'پیغام', html: message, className: className, hasOk: true, 'min-width': '300px', 'min-height': '90px' });
	},
	confirm: function(title, message, className, okCallback, cancelCallback, params) {
		this.show({ title: title,
			html: message,
			className: className,
			hasOk: true,
			hasCancel: true,
			okCallback: okCallback,
			cancelCallback: cancelCallback,
			params: params
		});
	}
};
$(document).on('click', '[data-lc-dlg-open]', function(e){
  lc$.Dialog.show({html:$($(e.target).closest('[data-lc-dlg-open]').attr('data-lc-dlg-open'))});	
});
//end lc$.Dialog
lc$.Help = {
	convert: function(hideEmpty) {
		var helpElements = $('[helptemplate]');
		helpElements.each(function() {
			var helpElement = $(this);
			if (hideEmpty && helpElement.html() == '')
				return;
			var template = $('#' + helpElement.attr('helptemplate')).html();
			helpElement.removeAttr('helptemplate');
			var helpContainer = $("<div class='help-container'/>");
			helpContainer.html(template);
			helpElement.helpContainer = helpContainer;
			helpElement.before(helpContainer);
			var helpContent = helpContainer.find('[helpcontent]');
			helpContent.before(helpElement);

			var uniqueId = 'helpbox' + lc$.uid();
			var helpBox = helpContainer.find('[helpbox]');
			helpBox.prop('id', uniqueId);
			var helpOpener = helpContainer.find('[helpopener]');
			helpOpener.attr('lcopentarget', '#' + uniqueId);
		});
	}
}
$(document).ready(lc$.Help.convert);
//End lc$.Help
lc$.Tab = {
	c: null,
	_hide: function(tabObject) {
		if (!tabObject) return;
		tabObject.header.removeClass('LocoSelect');
		tabObject.tabContainer.hide();
		if (tabObject.onHideScript) lc$.exec(tabObject.onHideScript);
	},
	_show: function(tabObject) {
		lc$.Tab._hide(tabObject.container.data('activeTabObject'));
		tabObject.header.addClass('LocoSelect');
		tabObject.tabContainer.show();
		tabObject.container.data('activeTabObject', tabObject);
		if (tabObject.onShowScript) lc$.exec(tabObject.onShowScript);
	},
	_headerClick: function(e) {
		var target = $(e.target).closest('[tabcontainer]');
		lc$.Tab._show(target.data('tabObject'));
	},
	_convert: function(container) {
		var headers = container.find('[tabcontainer]');
		headers.each(function(index) {
			var el = $(this);
			if (index == 0) el.attr('lc-firsttab', 'true');
			var tabContainer = $('#' + el.attr('tabcontainer'));
			var tabContent = $('#' + el.attr('tabcontent'));
			tabContainer.append(tabContent);
			tabContainer.hide();

			var tabObject = { container: container, header: el, tabContainer: tabContainer,
				onShowScript: el.attr('ontabshow'), onHideScript: el.attr('ontabhide')
			};
			el.data('tabObject', tabObject);
			tabContainer.data('tabObject', tabObject);
			//tabs.push(tabObject);
			el.on('click', lc$.Tab._headerClick);
		});
		if (headers.length > 0)
			lc$.Tab._show(container.find('[lc-firsttab]').data('tabObject'));
	},
	convert: function(el) { lc$.Tab._convert($(el)) }
}
$(document).ready(function() {
	$('.LocoTabContainer').each(function() { lc$.Tab._convert($(this)) });
});
//End lc$.Tab
lc$.Cookie = {
	create: function(name, value, days, topLevelDomain) {
		var expires = "";
		if (days) {
			var date = new Date();
			date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
			expires = "; expires=" + date.toGMTString();
		}
		var domain = "";
		if (topLevelDomain) {
			var parts = window.location.host.split('.');
			if (parts.length >= 2)
				domain = '.' + parts[parts.length - 2] + '.' + parts[parts.length - 1];
			else
				domain = window.location.host;
			domain = '; domain=' + domain;
		}

		document.cookie = name + "=" + encodeURIComponent(value) + expires + "; path=/" + domain;
	},
	read: function(name) {
		var nameEQ = name + "=";
		var ca = document.cookie.split(';');
		for (var i = 0; i < ca.length; i++) {
			var c = decodeURIComponent(ca[i]);
			while (c.charAt(0) == ' ') c = c.substring(1, c.length);
			if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
		}
		return null;
	},
	clear: function(name, topLevelDomain) {
		lc$.Cookie.create(name, "", -1, topLevelDomain);
	},
	setObject: function(name, obj, days) {
		lc$.Cookie.create(name, JSON.stringify(obj), days);
	},
	getObject: function(name) {
		var str = lc$.Cookie.read(name);
		if (str && str != '')
			return JSON.parse(str);
		return {};
	}
};
//End lc$.Cookie
/// lc$.Ajax and LocoAjax
lc$.Ajax = {
	callbackHandlers: [],
	addCallbackHandler: function(fn) {
		this.callbackHandlers.push(fn);
	},
	executeCallbackHandlers: function() {
		for (var i = 0; i < lc$.Ajax.callbackHandlers.length; i++) {
			var fn = lc$.Ajax.callbackHandlers[i];
			fn();
		}
		lc$.Ajax.callbackHandlers = [];
	},

	selectedClass: 'ajax-selected',
	autocompleteDalay: 500,
	callback: function(res) {
		lc$.Ajax.endAjaxProgress();
		if (!res || !res.value) {
			lc$.Ajax.showMessage(-1, 'یک خطای غیر مترقبه رخ داده است، لطفا چند لحظه بعد عملیات درخواستی خود را تکرار نمایید.');
			lc$.log(res);
			return;
		}
		lc$.exec(res.value.script, res);
		if (res.value.message && res.value.message != '') {
			lc$.Ajax.showMessage(res.value.messageType, res.value.message);
		}
		lc$.Ajax.executeCallbackHandlers();
	},
	reloadPage: function() {
		window.location.href = window.location.href;
	},
	showMessage: function(messageType, mesage) {
		lc$.log(mesage);

		if(!mesage || mesage == '')
			return;
		
		var messageBox = null;
		var messageBody = null;

		switch (messageType) {
			case -1:
				messageBox = $('#AjaxErrorMessage');
				messageBody = $('#ErrorMessage');
				break;
			case 0:
				messageBox = $('#AjaxWarningMessage');
				messageBody = $('#WarningMessage');
				break;
			case 1:
				messageBox = $('#AjaxSuccessMessage');
				messageBody = $('#SuccessMessage');
				break;
			case 2:
				messageBox = $('#AjaxInfoMessage');
				messageBody = $('#InfoMessage');
				break;
		}

		lc$.Ajax.hideMessage();
		messageBox.show();
		messageBody.html(mesage);

		setTimeout('lc$.Ajax.hideMessage()', 3000);
	},
	hideMessage: function() {
		$('#AjaxErrorMessage').hide();
		$('#AjaxWarningMessage').hide();
		$('#AjaxSuccessMessage').hide();
		$('#AjaxInfoMessage').hide();
	},
	startAjaxProgress: function() {
		//lc$.Ajax.hideMessage();
		$('#AjaxProgress').show();
	},
	endAjaxProgress: function() {
		//lc$.Ajax.hideMessage();
		$('#AjaxProgress').hide();
	},
	Transform: function(input, metaData, data) {
		return input.transform(metaData, data);
	}
}
/// End lc$.Ajax and LocoAjax
lc$.Nav = {
	_initialized: false,
	_event: 'lc$.Nav.event',
	_getHashParts: function() {
		var parameters = {};
		var target = '';
		var hash = window.location.hash;
		if (hash && hash != '') {
			var parts = hash.split('/');
			target = parts[0].replace('#', '');
			for (var i = 1; i < parts.length; i++) {
				var paramParts = parts[i].split('=');
				if (paramParts.length == 2)
					parameters[paramParts[0]] = paramParts[1];
			}
		}
		return { target: target, parameters: parameters };
	},
	_onUrlChange: function() {
		$(document).trigger(lc$.Nav._event, [lc$.Nav._getHashParts()]);
	},
	attach: function(loadFn) {
		if (!lc$.Nav._initialized) {
			$(window).on('load', lc$.Nav._onUrlChange);
			$(window).on('hashchange', lc$.Nav._onUrlChange);
			lc$.Nav._initialized = true;
		}
		$(document).on(lc$.Nav._event, function(e, args) { loadFn(args.target, args.parameters) });
	},
	navigate: function(target, parameters) {
		var hash = '#' + target;
		if (parameters)
			for (var p in parameters)
			if (parameters[p])
			hash += '/' + p + '=' + parameters[p];
		if (window.location.hash != hash)
			window.location.hash = hash;
	},
	getTarget: function() {
		return lc$.Nav._getHashParts().target;
	},
	getParameters: function() {
		return lc$.Nav._getHashParts().parameters;
	}
};
//end lc$.Nav
lc$.Drag = {
	dragObj: $(),
	attach: function(handleEl, boxEl) {
		$(handleEl).on('mousedown', function(e) { lc$.Drag.start(e, $(boxEl)); })
	},
	start: function(e, el) {
		if (!lc$.Drag.dragObj.zIndex)
			lc$.Drag.dragObj.zIndex = 0;

		if (el) {
			if (el.exists())
				lc$.Drag.dragObj.el = el;
			else
				lc$.Drag.dragObj.el = $('#' + el);
		}
		else {
			lc$.Drag.dragObj.el = $(e.target);
		}

		lc$.Drag.dragObj.startXY = { X: e.clientX, Y: clientY }
		lc$.Drag.dragObj.elStartLeft = lc$.Drag.dragObj.el.offset().left
		lc$.Drag.dragObj.elStartTop = lc$.Drag.dragObj.el.offset().top;

		//lc$.Drag.dragObj.el.style.zIndex = ++lc$.Drag.dragObj.zIndex;

		$(document).on('mousemove', lc$.Drag.dragGo);
		$(document).on('mouseup', lc$.Drag.dragStop);
	},
	dragGo: function(e) {
		lc$.Drag.dragObj.el.offset({
			top: (lc$.Drag.dragObj.elStartTop + e.clientY - lc$.Drag.dragObj.startXY.Y),
			left: (lc$.Drag.dragObj.elStartLeft + e.clientX - lc$.Drag.dragObj.startXY.X)
		});

		e.preventDefault();
		e.stopPropagation();
	},
	dragStop: function(e) {
		$(document).off('mousemove', lc$.Drag.dragGo);
		$(document).off('mouseup', lc$.Drag.dragStop);
	}
};
//end lc$.Drag
//lc$.Pager
lc$.Pager = function(o) {
	this.currentPage = 1;
	this.itemCount = 999999999;
	this.pageSize = 5;
	this.firstElements = $();
	this.prevElements = $();
	this.nextElements = $();
	this.lastElements = $();
	this.countElements = $();
	this.fromElements = $();
	this.toElements = $();
	this.onPageChange = function(pager) { };

	$.extend(this, o);

	this.firstElements = $(this.firstElements);
	this.prevElements = $(this.prevElements);
	this.nextElements = $(this.nextElements);
	this.lastElements = $(this.lastElements);
	this.countElements = $(this.countElements);
	this.fromElements = $(this.fromElements);
	this.toElements = $(this.toElements);

	var self = this;
	this.firstElements.on('click', function() { self.first(); });
	this.prevElements.on('click', function() { self.previous(); });
	this.nextElements.on('click', function() { self.next(); });
	this.lastElements.on('click', function() { self.last(); });
}

lc$.Pager.prototype = {
	from: function() {
		if (this.itemCount <= 0)
			return 0;
		return (this.pageSize * (this.currentPage - 1)) + 1;
	},
	to: function() {
		if (this.itemCount <= 0)
			return -1;
		var temp = this.pageSize * this.currentPage;
		return temp > this.itemCount ? this.itemCount : temp;
	},
	last: function() {
		if (this.isLastPage())
			return;
		this.currentPage = this.pageCount();
		this.reload();
	},
	first: function() {
		if (this.isFirstPage())
			return;
		this.currentPage = 1;
		this.reload();
	},
	next: function() {
		if (this.isLastPage())
			return;
		this.currentPage++;
		this.reload();
	},
	previous: function() {
		if (this.isFirstPage())
			return;
		this.currentPage--;
		this.reload();
	},
	onPageChangeEvent: function() {
		if (this.onPageChange)
			this.onPageChange(this);
	},
	isFirstPage: function() {
		return (this.itemCount <= 0 || this.currentPage == 1);
	},
	isLastPage: function() {
		return (this.itemCount <= 0 || this.currentPage == this.pageCount());
	},
	pageCount: function() {
		if (this.itemCount <= 0)
			return 0;
		return Math.floor(this.itemCount / this.pageSize) + ((this.itemCount % this.pageSize == 0) ? 0 : 1);
	},
	reload: function(goToFirstPage) {
		if (goToFirstPage) {
			this.currentPage = 1;
			this.itemCount = 1000;
		}
		if (this.currentPage > this.pageCount())
			this.currentPage = this.pageCount();
		this.onPageChangeEvent();
		this.render();
	},
	render: function() {
		$(this.firstElements.add(this.prevElements).add(this.nextElements).add(this.lastElements)).removeClass('LocoDisabled').removeProp('disabled');

		if (this.isFirstPage())
			$(this.firstElements.add(this.prevElements)).addClass('LocoDisabled').prop('disabled', true);

		if (this.isLastPage())
			$(this.nextElements.add(this.lastElements)).addClass('LocoDisabled').prop('disabled', true);

		this.fromElements.text(this.from());
		this.toElements.text(this.to());
		this.countElements.text(this.itemCount);
	}
}
//End lc$.Pager
//begin controls
//Comma Selector
function CommaSelector(o) {
	this.clientId = '';
	this.maxWords = 0;
	this.acceptDuplicateWord = false;

	$.extend(this, o);

	this.inputElement = $('#' + this.clientId + '_InputTextBox');
	this.wordsElement = $('#' + this.clientId + '_ItemsHiddenField');
	this.wordsHolderElement = $('#' + this.clientId + '_MonitorPanel');

	this.refresh();
}
CommaSelector.prototype = {
	_getWordList: function() {
		var result = new Array();
		var words = this.wordsElement.val().split('$');
		for (var i = 0; i < words.length; i++)
			if (words[i] != '')
			result.push(words[i]);
		return result;
	},
	refresh: function() {
		var self = this;
		this.wordsHolderElement.html('');
		var wordList = this._getWordList();
		for (var i = 0; i < wordList.length; i++)
			if (wordList[i] && wordList[i] != '') {
			var el = $('<a href="javascript:void(0)">' + wordList[i] + '</a>');
			el.attr('word', wordList[i]);
			el.on('click', function() { self._remove(this) });
			this.wordsHolderElement.append(el);
		}
	},
	add: function() {
		var word = this.inputElement.val();
		var wordList = this._getWordList();
		if (this.maxWords != 0 && wordList.length >= this.maxWords)
			return;
		if (!this.acceptDuplicateWord)
			for (var i = 0; i < wordList.length; i++)
			if (word == wordList[i]) return;
		var val = this.wordsElement.val();
		if (val.length > 0 && val[val.length - 1] != '$')
			val += '$';
		val += word + '$';
		this.wordsElement.val(val);
		this.refresh();
		this.inputElement.val('');
	},
	_remove: function(el) {
		el = $(el);
		var wordList = this._getWordList();
		var word = el.attr('word');
		var val = '';
		for (var i = 0; i < wordList.length; i++)
			if (word != wordList[i])
			val += wordList[i] + '$';

		this.wordsElement.val(val);
		this.refresh();
	},
	setValue: function(val) {
		this.wordsElement.val(val);
		this.refresh();
	},
	getValue: function() {
		return this.wordsElement.val();
	}
}
//End CommaSelector
//TextBox
$(document.body).on('keypress', '[lc-defaultscript]', function(event) {
	if (event.keyCode != 13) return;
	var el = $(event.target);
	lc$.exec(el.attr('lc-defaultscript'));
	return false;
});
$(document.body).on('keyup', '[lc-lang]', function(event) {
	var input = $(event.target);
	var lang = input.attr('lc-lang');
	var val = input.val();
	switch (lang.toLowerCase()) {
		case 'fa':
			val = val.toFa();
			break;
		case 'en':
			val = val.toEn();
			break;
	}
	input.setValue(val, true);
});
//End TextBox
function LocoPopupOpener(o) {
	this.options = { popupPage: 'Popup.aspx', objectName: '', width: '800', height: '400', closeCallback: function() { }, commandCallback: function() { } };
	$.extend(this.options, o);
}
LocoPopupOpener.prototype = {
	open: function(queryString, title) {
		queryString = queryString ? queryString : '';
		var url = this.options.popupPage + '?PopupOpener_CloseCallback=' + this.options.objectName + '.close&PopupOpener_CommandCallback=' + this.options.objectName + '.command&rnd=' + Math.random() + '&' + queryString;
		TINY.box.show({ iframe: url, title: title, close: true, width: this.options.width, height: this.options.height });
	},
	close: function(value) {
		var refresh = true;
		if (this.options.closeCallback)
			refresh = this.options.closeCallback(value);
		TINY.box.hide();
		if (refresh)
			window.location = window.document.URL;
	},
	command: function(value) {
		var refresh = true;
		if (this.options.commandCallback)
			refresh = this.options.commandCallback(value);
		if (refresh)
			window.location = window.document.URL;
	}
}
//End LocoPopupOpener
function LocoAjaxSelector(o) {
	this.name = '';
	this.clientId = '';
	this.ajaxClass = null;
	this.itemMetaData = null;
	this.initialSelectedItems = [];
	this.scriptItemMetaData = null;
	this.scriptItems = [];
	this.maxSelectedItems = -1;
	this.enableSearch = true;
	this.enableDefaults = true;
	this.enableUserEntry = true;
	this.searchText = '';
	this.metadata = '';
	this.maskText = '';
	this.onSelectionChanged = function(selector) { };

	$.extend(this, o);

	this.setContainers();
	this.setTemplates();

	this.displayMode = 'add';
	this.activeItemIndex = -1;
	this.activeItem = null;

	this.defaultItemKeys = [];
	this.searchItemKeys = [];
	this.selectedItemKeys = [];
	this.items = {};

	this.setInitialSelectedItems();
	this.getDefaultItems();
	
	if (this.maxSelectedItems == -1 || this.selectedItemKeys.length < this.maxSelectedItems) {
		this.setDisplay('add');
	}
	else
		this.setDisplay('full');
}

LocoAjaxSelector.prototype = {
	setContainers: function() {
		var self = this;

		this.containerDiv = $('#' + this.clientId + '_Container');
		this.containerDiv.append($(
			"<div data-fm-el='items-box' class='AddContact'>" +
			"	<span data-fm-el='selected-items-container' class='SelectedItemsSpan'></span>" +
			//"	<span data-fm-el='add-btn' class='AddContactBtn'></span>" +
			"	<input type='text' data-fm-el='search-input' class='AddContactSearch' />" +
			"	<div style='clear: both'>" +
			"	</div>" +
			"</div>" +
			"<div data-fm-el='suggestions-container' class='ResultBox' style='display:none'>" +
			"	<div data-fm-el='defaults-container' class='DefaultItemsBox'>" +
			"	</div>" +
			"	<div data-fm-el='search-result-box' class='SearchResultBox'>" +
			"		<div data-fm-el='search-result-container' class='SearchResult'>" +
			"		</div>" +
			"	</div>" +
			"</div>"
		));

		this.selectedItemsContainer = this.containerDiv.lc_findElement('selected-items-container');

		this.searchInput = this.containerDiv.lc_findElement('search-input');
		this.searchInput.attr('placeholder', this.maskText);
		this.searchInput.on('focus', function(e, preventHandler) { if(!preventHandler) self.setDisplay('defaults') });
		this.searchInput.on('keydown', function(e) { return self.processInput(e) });
		this.searchInput.on('keypress', function(e) { e.stopPropagation() });
		this.searchInput.on('blur', function(e) { self.selectByKey($(e.target).val()) });
		if(this.containerDiv.parent().hasAttr('tabindex')){
			var tabIndex = this.containerDiv.parent().attr('tabindex');			
			this.containerDiv.parent().removeAttr('tabindex');
			this.searchInput.attr('tabindex', tabIndex);
		}


		this.suggestionContainer = this.containerDiv.lc_findElement('suggestions-container');
		this.defaultsContainer = this.containerDiv.lc_findElement('defaults-container');
		this.searchResultBox = this.containerDiv.lc_findElement('search-result-box');
		this.searchResultContainer = this.containerDiv.lc_findElement('search-result-container');
	},
	setTemplates: function() {
		var self = this;

		this.selectedItemTemplate =
			"<span class='Item #Type#' value='#Value#' data-selected-key='#Key#'>" +
			"	<img src='images/null.gif' class='icons #Type#' />" +
			"	<img src='#Icon#' class='img' />" +
			"	<span class='content'>#Title#</span>" +
			"</span>";
		this.containerDiv.on('click', '[data-selected-key]',
			function(e) {
				e.stopPropagation();
				self.deselect($(e.target).closest('[data-selected-key]').attr('data-selected-key'))
			});

		this.defaultItemTemplate =
			"<span class='#Type#' value='#Value#'	data-item-key='#Key#'>" +
			"	<img src='images/null.gif' class='icons #Type#' />" +
			"	<img src='#Icon#' class='img' />" +
			"	<span class='content'>#Title#</span>" +
			"</span>";
		this.searchItemTemplate =
			"<span class='#Type#' value='#Value#'	data-item-key='#Key#'>" +
			"	<img src='images/null.gif' class='icons #Type#' />" +
			"	<img src='#Icon#' class='img' />" +
			"	<span class='content'>#Title#</span>" +
			"</span>";

		this.containerDiv.on('click', '[data-item-key]',
			function(e) {
				e.stopPropagation();
				self.selectByKey($(e.target).closest('[data-item-key]').attr('data-item-key'));
			});


		this.scriptItemTemplate =
			"<span data-script='#ScriptFunction#'>" +
			"	<span class='Icon' style='background-image: #Icon#'></span>" +
			"	<a href='#Link#'>#Title#</a>" +
			"</span>";
		this.containerDiv.on('click', '[data-script]',
			function(e) {
				e.stopPropagation();
				self.runScript($(e.target).closest('[data-script]').attr('data-script'));
			});

		this.spacerTemplate = "<hr class='hr'>";
	},
	addItem: function(item) {
		if (item.Key == '' || this.items[item.Key])
			return;
		this.items[item.Key] = item;
	},
	renderDefaultItems: function() {
		if (!this.enableDefaults || this.displayMode != 'defaults')
			return;
		this.defaultsContainer.empty();
		this.defaultsContainer.items = [];
		var spacer = true;
		this.defaultItemKeysCount = -1;
		for (var i = 0; i < this.defaultItemKeys.length; i++) {
			var selected = 'class="Item"';
			var item = this.items[this.defaultItemKeys[i]];
			if (item && !this.selectedItemKeys.find(item.Key)) {
				this.defaultItemKeysCount++;
				if (this.displayMode == 'defaults' && this.defaultItemKeysCount == this.activeItemIndex) {
					this.activeItem = item;
					selected = 'class="Item select"';
				}
				this.defaultsContainer.append($('<span ' + selected + '>' + lc$.Ajax.Transform(this.defaultItemTemplate, this.itemMetaData, [item]) + '</span>'));
				this.defaultsContainer.items.push(item);
				selected = 'class="Item"';
				spacer = false;
			}
			else if (!spacer) {
				this.defaultsContainer.append($(this.spacerTemplate));
				spacer = true;
			}
		}

		if (this.scriptItems.length > 0)
			this.addScriptItems(this.defaultsContainer);
		var selectedSpans = this.defaultsContainer.find('.select');
		if (selectedSpans.length > 0)
			selectedSpans[0].scrollIntoView(false);
		
		if(this.defaultsContainer.find('.Item').length > 0)
			this.defaultsContainer.show();
		else
			this.defaultsContainer.hide();

	},
	addScriptItems: function(box) {
		box.show();
		box.append($(this.spacerTemplate));
		for (var i = 0; i < this.scriptItems.length; i++) {
			var selected = 'class="Item"';
			var item = this.scriptItems[i];
			this.defaultItemKeysCount++;
			this.searchItemKeysCount++;
			if (
				(this.displayMode == 'defaults' && this.defaultItemKeysCount == this.activeItemIndex) ||
				(this.displayMode == 'search' && this.searchItemKeysCount == this.activeItemIndex)
				) {
				this.activeItem = item;
				selected = 'class="Item select"';
			}
			box.append($('<span ' + selected + '>' + lc$.Ajax.Transform(this.scriptItemTemplate, this.scriptItemMetaData, [item]) + '</span>'));
			box.items.push(item);
			selected = 'class="Item"';
			spacer = false;
		}

	},
	renderSearchItems: function() {
		if (!this.enableSearch || this.displayMode != 'search')
			return;
		this.searchResultContainer.empty();
		this.searchResultContainer.items = [];
		var spacer = true;
		this.searchItemKeysCount = -1;
		for (var i = 0; i < this.searchItemKeys.length; i++) {
			var selected = 'class="Item"';
			var item = this.items[this.searchItemKeys[i]];
			if (item && !this.selectedItemKeys.find(item.Key)) {
				this.searchItemKeysCount++;
				if (this.displayMode == 'search' && this.searchItemKeysCount == this.activeItemIndex) {
					this.activeItem = item;
					selected = 'class="Item select"';
				}
				this.searchResultContainer.append($('<span ' + selected + '>' + lc$.Ajax.Transform(this.searchItemTemplate, this.itemMetaData, [item]) + '</span>'));
				this.searchResultContainer.items.push(item);
				spacer = false;
			}
			else if (!spacer) {
				this.searchResultContainer.append($(this.spacerTemplate));
				spacer = true;
			}
		}
		if (this.scriptItems.length > 0)
			this.addScriptItems(this.searchResultContainer);

		var selectedSpans = this.searchResultContainer.find('.select');
		if (selectedSpans.length > 0)
			selectedSpans[0].scrollIntoView(false);

	},
	clearSelection: function() {
		this.selectedItemKeys = [];
		this.setDisplay('add');
	},
	getSelectedKeys: function() {
		return this.selectedItemKeys;
	},
	getSelectedItems: function() {
		var selectedItems = [];
		var selectedKeys = this.getSelectedKeys();
		for (var i = 0; i < selectedKeys.length; i++) {
			var item = this.items[selectedKeys[i]];
			selectedItems.push(item);
		}
		return selectedItems;
	},
	renderSelectedItems: function() {
		this.selectedItemsContainer.html($(lc$.Ajax.Transform(this.selectedItemTemplate, this.itemMetaData, this.getSelectedItems())));
	},
	render: function() {
		this.renderSelectedItems();
		this.renderDefaultItems();
		this.renderSearchItems();
	},
	createItem: function(key) {
		var item = { Key: key, Type: '', Value: key, Title: key, Description: '', Icon: '', BgColor: '', TextColor: '' };
		this.addItem(item);
		return item;
	},
	selectByKey: function(key) {
		var item = this.items[key];
		if (!item && this.enableUserEntry && key.trim() != '') {
			item = this.createItem(key);
			item.userEntry = true;
		}
		if (item)
			this.select(item);
	},
	select: function(item) {
		if (this.maxSelectedItems == -1 || this.selectedItemKeys.length < this.maxSelectedItems)
			this.selectedItemKeys.push(item.Key);
		this.activeItemIndex = -1;
		this.activeItem = null;
		this.searchInput.val('');
		if (this.maxSelectedItems == -1 || this.selectedItemKeys.length < this.maxSelectedItems) {
			this.setDisplay('defaults');
		}
		else
			this.setDisplay('full');
		if (this.onSelectionChanged)
			this.onSelectionChanged(this);
	},
	deselect: function(key) {
		this.selectedItemKeys.remove(key);
		this.setDisplay('defaults');
		if (this.onSelectionChanged)
			this.onSelectionChanged(this);
	},
	selectActiveItem: function() {
		if (this.activeItemIndex >= 0 && this.activeItem) {
			if (this.activeItem.Key)
				this.select(this.activeItem);
			else if (this.activeItem.ScriptFunction)
				this.runScript(this.activeItem.ScriptFunction);
		}
		else {
			if (this.enableUserEntry)
				this.selectByKey(this.searchInput.val());
			else
				this.search();
		}
		clearTimeout(this.searchTimeOut);
	},
	moveActive: function(delta) {
		this.activeItemIndex += delta;
		if (this.activeItemIndex < -1)
			this.activeItemIndex = -1;

		var items = [];
		var itemSpans = $();
		switch (this.displayMode) {
			case 'add':
				this.activeItemIndex = -1;
				this.searchInput.val('');
				break;
			case 'defaults':
				if (this.activeItemIndex > this.defaultItemKeysCount)
					this.activeItemIndex = 0;
				items = this.defaultsContainer.items;
				itemSpans = this.defaultsContainer.find('.Item');
				break;
			case 'search':
				if (this.activeItemIndex > this.searchItemKeysCount)
					this.activeItemIndex = 0;
				items = this.searchResultContainer.items;
				itemSpans = this.searchResultContainer.find('.Item');
				break;
		}

		if (this.activeItemIndex > -1 && this.activeItemIndex < items.length)
			this.activeItem = items[this.activeItemIndex];
		else
			this.activeItem = null;

		itemSpans.removeClass('select');
		for (var i = 0; i < itemSpans.length; i++) {
			if (this.activeItemIndex == i) {
				$(itemSpans[i]).addClass('select');
				itemSpans[i].scrollIntoView(false);
			}
		}
	},
	removeLast: function() {
		this.selectedItemKeys.pop();
		this.setDisplay('defaults');
	},
	setDisplay: function(displayMode) {
		var self = this;
		if (displayMode)
			this.displayMode = displayMode;
		switch (this.displayMode) {
			case 'add':
				this.searchInput.show();
				this.defaultsContainer.hide();
				this.searchResultBox.hide();
				break;
			case 'full':
				this.searchInput.hide();
				this.defaultsContainer.hide();
				this.searchResultBox.hide();
				break;
			case 'defaults':
				if (this.enableDefaults) {
					if (!self.suggestionContainer.is(':visible'))
						lc$.TargetOpener.open({ opener: self.searchInput, target: self.suggestionContainer, onClose: function() { self.close() } });
					this.displayMode = 'defaults';
					this.searchInput.show();
					this.defaultsContainer.show();
					this.searchResultBox.hide();
				}
				else {
					this.defaultsContainer.hide();
					this.searchResultBox.hide();
				}
				this.searchInput.show();
				this.searchInput.trigger('focus', [true]);
				break;
			case 'search':
				if (!self.suggestionContainer.is(':visible'))
					lc$.TargetOpener.open({ opener: self.searchInput, target: self.suggestionContainer, onClose: function() { self.close() } });
				this.displayMode = 'search';
				this.searchInput.show();
				this.defaultsContainer.hide();
				break;
		}
		this.render();
	},
	close: function() {
		if (this.maxSelectedItems == -1 || this.selectedItemKeys.length < this.maxSelectedItems) {
			this.setDisplay('add');
		}
		else
			this.setDisplay('full');
	},
	setInitialSelectedItems: function() {
		for (var i = 0; i < this.initialSelectedItems.length; i++) {
			this.addItem(this.initialSelectedItems[i]);
			this.selectedItemKeys.push(this.initialSelectedItems[i].Key);
		}
		this.render();
	},
	setSelectedItems: function(items) {
		this.initialSelectedItems = items;
		this.setInitialSelectedItems();
	},
	getDefaultItems: function() {
		lc$.Ajax.startAjaxProgress();
		this.ajaxClass.AjaxGetDefaultItems(this.name, this.metadata, lc$.Ajax.callback);
	},
	getDefaultItemsCallback: function(items) {
		this.defaultItemKeys = [];
		for (var i = 0; i < items.length; i++) {
			var item = items[i];
			this.addItem(item);
			this.defaultItemKeys.push(item.Key)
		}
		this.render();
	},
	processInput: function(event) {
		if (!event)
			return;
		event.stopPropagation();
		var keyCode = event.keyCode;

		//alert(keyCode);
		switch (keyCode) {
			case 13:
				this.selectActiveItem();
				return false;
			case 8:
				if (this.searchInput.val().length == '') {
					this.removeLast();
					return false;
				}
				break;
			case 38:
				this.moveActive(-1);
				return false;
			case 40:
				this.moveActive(1);
				return false;
			case 9:
				this.setDisplay('add');
				return true;
			default:
				break;
		}
		if (this.enableSearch) {
			if (this.searchTimeOut)
				clearTimeout(this.searchTimeOut);
			this.searchTimeOut = setTimeout(this.name + '.search()', 800);
		}
	},
	search: function() {
		if (this.searchInput.val() == '')
			this.setDisplay('defaults');
		else {
			lc$.Ajax.startAjaxProgress();
			this.ajaxClass.AjaxGetSearchItems(this.name, this.searchInput.val(), this.metadata, lc$.Ajax.callback);
		}
	},
	searchCallback: function(items) {
		if (items.length == 0) {
			this.searchResultBox.hide();
			this.searchItemKeys = [];
			this.activeItemIndex = -1;
			this.setDisplay('search');
			return;
		}

		this.searchItemKeys = [];
		for (var i = 0; i < items.length; i++) {
			var item = items[i];
			this.addItem(item);
			this.searchItemKeys.push(item.Key)
		}
			this.searchResultBox.show();
		this.activeItemIndex = -1;
		this.activeItem = null;
		this.setDisplay('search');
		this.moveActive(1);
	},
	runScript: function(script) {
		lc$.exec(script + '(\'' + this.searchInput.val() + '\');');
	}
}
//end LocoAjaxSelector
function LocoCustomFieldsControl(o) {
	this.inputIds = {};
	this.clientId = '';
	this.validationGroup = '';
	this.ajaxClass = null;
	this.onGetFields = function() { };

	$.extend(this, o);
	window[this.clientId] = this;

	this.container = $('#' + this.clientId);
	this.container.attr('type', 'customfieldscontrol');
	this.container.data('customfieldscontrol', this);

	this._setValidationGroup();
}
LocoCustomFieldsControl.prototype = {
	_setValidationGroup: function() {
		for (var key in this.inputIds) {
			$('#' + this.inputIds[key]).attr('validationgroup', this.validationGroup);
		}
	},
	getValue: function(key) {
		return $('#' + this.inputIds[key]).getValue() + '';
	},
	getValues: function() {
		var result = [];
		var i = 0;
		for (var key in this.inputIds) {
			result.push({ Key: key, Value: this.getValue(key) });
		}
		return result;
	},
	setValue: function(key, value) {
		$('#' + this.inputIds[key]).setValue(value);
	},
	setValues: function(keyValues) {
		for (var i = 0; i < keyValues.length; i++)
			this.setValue(keyValues[i].Key, keyValues[i].Value);
	},
	getFields: function(metaData, keyValues) {
		this._rawValues = keyValues;
		this.ajaxClass.AjaxGetCustomFields(this.clientId, metaData, lc$.Ajax.callback);
	},
	getFieldsCallback: function(inputIds, html, script) {
		$('#' + this.clientId).replaceWith($(html));
		this.inputIds = inputIds;
		lc$.exec(script);
		if (this._rawValues)
			this.setValues(this._rawValues);
		this._setValidationGroup();
		lc$.Help.convert(true);
		if (this.onGetFields)
			this.onGetFields();
	}
}
//end LocoCustomFieldsControl
//LocoColorSelector
function LocoColorSelector(o) {
	this.clientId = '';
	this.colors = [];
	this.selectedColor = function() { };
	this.onColorChange = function() { };

	$.extend(this, o);

	this.objectName = 'LocoColorSelector.' + this.clientId;
	this.showColorList = false;
	var self = this;
	this.containerDiv = $('#' + this.clientId + '_Container');
	this.containerDiv.append($(
			"<div  class='IndicatorDiv ColorIcon' " +
			"		lcopentarget='#" + this.clientId + "_Container .ColorList' onopentarget='" + this.objectName + ".open()' onclosetarget='" + this.objectName + ".close()'>" +
			"	<span class='IndicatorSpan'></span>" +
			"</div>" +
			"<div class='ColorList color-slt-pup clrfx' style='display:none'>" +
			"</div>"));

	this.indicatorDiv = this.containerDiv.find('.IndicatorDiv');
	this.indicatorSpan = this.containerDiv.find('.IndicatorSpan');
	this.indicatorSpan.attr('style', 'background-color: #' + this.selectedColor);
	this.colorsDiv = this.containerDiv.find('.ColorList');
	this.createColorCells();
	this.selectedColorCell = this.colorsDiv.find('.LocoSelect');
}
LocoColorSelector.prototype = {
	createColorCells: function() {
		if(!this.colors || this.colors.length == 0){
			this.colors = [
				["663300", "A5021", "660066", "000066", "003366", "003300", "080808"],
				["CC9900", "CC0000", "CC00CC", "3333FF", "006699", "008000", "505050"],
				["CCCC00", "FF0000", "CC0099", "3333CC", "0099CC", "00CC00", "7A7A7A"],
				["99CC00", "FF3300", "CC3399", "6600FF", "0066CC", "00CC66", "5E4646"],
				["669900", "CC6600", "D60093", "9933FF", "0033CC", "00CC99", "534358"],
				["009900", "FF9900", "CC0066", "FF42F8", "0000FF", "009999", "4A5C4A"]
			];
		}
		
		var html = '';
		for (var i = 0; i < this.colors.length; i++) {
			html += '<div	class="clrfx">';
			for (var j = 0; j < this.colors[i].length; j++) {
				var color = this.colors[i][j];
				html += '<span ' + 
								'	lc-color="' + color + '"' +
								'	style="background-color:#' + color + '"' +
								'	class="Color ' + (this.selectedColor == color ? 'icons LocoSelect' : '')  + '"' +
								'></span>';
			}
			html += '</div>';
		}
		
		this.colorsDiv.html(html);
		
		var self = this;
		this.colorsDiv.find('[lc-color]').on('click', function(e){
			e.stopPropagation();
			self.selectColor($(this).attr('lc-color'));
		});
	},
	close: function() {
		this.showColorList = false;
		this.indicatorDiv.removeClass('ColorSelect');
	},
	open: function() {
		this.showColorList = true;
		this.indicatorDiv.addClass('ColorSelect');
	},
	selectColor: function(color) {
		el = this.colorsDiv.find('[lc-color=' + color + ']');

		this.selectedColor = color;
		this.selectedColorCell.removeClass('icons LocoSelect');
		this.selectedColorCell = el;
		this.selectedColorCell.addClass('icons LocoSelect');
		this.indicatorSpan.attr('style', 'background-color: #' + this.selectedColor);
		this.close();
		//lc$.TargetOpener.close(this.colorsDiv);
		if (this.onColorChange)
			this.onColorChange();
	}
}
//end LocoColorSelector
function LocoMultiFieldRepeater(o) {
	this.container = null;
	this.rowTemplate = '';
	$.extend(this, o);

	this.inputs = {};
	this.index = -1;

	this.container.attr('type', 'multifieldrepeater');
	this.container.data('multifieldrepeater', this);
}
LocoMultiFieldRepeater.prototype = {
	_addRow: function(values) {
		var lastRow = this.container.find('[lc-row=' + this.index + ']');
		lastRow.find('[lc-btn=add]').hide();
		lastRow.find('[lc-btn=remove]').show();

		this.index++;


		var self = this;
		var row = $(
			"<span lc-row='" + this.index + "' >" +
			"	<div class='in-2 smallest first-child'>&nbsp;</div>" +
			this.rowTemplate +
			"	<span lc-btn='remove' class='icons cross dark'  />" +
			"	<span lc-btn='add' class='icons New' />" +
			"</span>");
		this.container.append(row);

		row.find('[lc-btn=add]').on('click', function(e) { self._addRow(); });
		row.find('[lc-btn=remove]').on('click', function(e) { self._removeRow($(e.target).closest('[lc-row]').attr('lc-row')); });
		row.find('[lc-btn=remove]').hide();


		var rowInputs = row.find('[field]');
		this.inputs['i' + this.index] = rowInputs;

		if (values) {
			rowInputs.each(function() {
				var field = $(this).attr('field');
				if (values[field])
					$(this).setValue(values[field]);
			});
		}
	},
	_removeRow: function(index) {
		delete this.inputs['i' + index];
		var row = this.container.find('[lc-row=' + index + ']');
		row.remove();

		var rows = this.container.find('[lc-row]');
		rows.first().find('[lc-btn=remove]').hide();
		rows.find('[lc-btn=add]').hide();
		rows.last().find('[lc-btn=add]').show();
	},
	clear: function() {
		this.container.empty();
		this.inputs = {};
		this.index = -1;
	},
	setValues: function(values) {
		this.clear();
		if (values && values.length > 0) {
			for (var i = 0; i < values.length; i++) {
				this._addRow(values[i]);
			}
		}
		else
			this._addRow();
	},
	getValues: function() {
		var results = [];
		for (var key in this.inputs) {
			var arr = this.inputs[key];
			var obj = new Object();
			for (var j = 0; j < arr.length; j++) {
				var input = $(arr[j]);
				var field = input.attr('field');
				var value = input.getValue();
				obj[field] = value;
			}
			results.push(obj);
		}
		return results;
	}
}
//end LocoMultifieldRepeater
function LocoHierarchySelector(o) {
	this.objectName = '';
	this.levels = [];
	this.values = [];
	this.selectedValues = [];
	this.hiddenTopLevels = 0;
	this.selectCaption = '';
	this.metaData = '';
	this.selectMode = 'ShowSelectCaption';
	this.ajaxClass = null;

	$.extend(this, o);

	this.template = '<span >#Title#</span><select disabled="disabled"></select>';
	this.hidden = $('#' + this.objectName);
	this.container = $('#' + this.objectName + '_Container');
	this.levelElements = [];
	this.selectElements = [];
	document[this.objectName] = LocoHierarchySelector[this.objectName] = this;

	this._init();
}
LocoHierarchySelector.prototype = {
	_init: function() {
		if (!this.container)
			return;
		var self = this;
		this.container.data('hierarchySelector', this);
		this.container.attr('hierarchySelectorContainer', 'hierarchySelectorContainer');
		this.container.empty();
		var hasLastValue = true;
		for (var i = 0; i < this.levels.length; i++) {
			var level = this.levels[i];
			var levelElement = $(
					'<div class="selector level-' + i + (i < this.hiddenTopLevels ? ' LocoHide' : '') + '">' +
					this.template.replace(/#Title#/gi, level) +
					'</div>');
			this.container.append(levelElement);
			var select = levelElement.find('select');
			select.data('level', i);
			if (!hasLastValue)
				continue;
			if (this.selectMode == 'ShowSelectCaption')
				select.addOption('', this.selectCaption);
			if (this.values.length > i && this.values[i].length > 0) {
				select.enable();
				for (var j = 0; j < this.values[i].length; j++) {
					select.addOption(this.values[i][j].Value, this.values[i][j].Text);
				}
			}
			selectedValue = (this.selectedValues.length > i) ? this.selectedValues[i] : '';
			select.val(selectedValue);
			if (select.prop('selectedIndex') < 0)
				select.prop('selectedIndex', 0);
			hasLastValue = (select.val() != '');
		}
		this.levelElements = this.container.find('.selector');
		this.selectElements = this.container.find('select'); ;
		this.selectElements.on('change', function(e) { self.onChange($(e.target)) });
		this._refreshSelectedValues();
	},
	_refreshSelectedValues: function() {
		var selectedValues = [];
		var val = '';
		this.selectElements.each(function() {
			var select = $(this);
			if (select.prop('disabled')) return;
			selectedValues.push(select.val());
			val += select.val() + ',';
		});
		this.selectedValues = selectedValues;
		var lastComma = /,$/;
		this.hidden.val(val.replace(lastComma, ''));
	},
	getSelectedValues: function() {
		return this.selectedValues;
	},
	setSelectedValues: function(values) {
		if (!values || values.length == 0)
			return;
		this.ajaxClass.AjaxSetSelectedValues(
					this.objectName,
					values,
					this.metaData,
					lc$.Ajax.callback);
	},
	setSelectedValuesCallback: function(values, selectedValues) {
		this.values = values;
		this.selectedValues = selectedValues;
		var self = this;
		this.selectElements.each(function(i) {
			var select = $(this);
			select.empty();
			select.disable();
			if (self.selectMode == 'ShowSelectCaption')
				select.addOption('', self.selectCaption);
			if (values.length > i) {
				for (var j = 0; j < values[i].length; j++) {
					select.addOption(values[i][j].Value, values[i][j].Text);
				}
				select.val(selectedValues[i]);
				if (select.prop('selectedIndex') < 0)
					select.prop('selectedIndex', 0);
				select.enable();
			}
		});
	},
	changeMetaData: function(metaData, callbackFn) {
		this.metaData = metaData;
		this.changeMetaDataCallbackFn = callbackFn;
		this.ajaxClass.AjaxChangeMetaData(
					this.objectName,
					this.metaData,
					lc$.Ajax.callback);
	},
	changeMetaDataCallback: function(levelsData, values) {
		this.levels = levelsData;
		this.values = values;
		this._init();
		if ($.isFunction(this.changeMetaDataCallbackFn))
			lc$.exec(this.changeMetaDataCallbackFn);
		this.changeMetaDataCallbackFn = null;
	},

	onChange: function(select) {
		if (!select)
			return;
		var level = select.data('level');
		if (level >= this.levelElements.length)
			return;
		this.selectElements.each(function(i) {
			if (i > level) {
				$(this).empty();
				$(this).disable();
			}
		});
		if (select.val() != '') {
			$(this.levelElements[level + 1]).addClass('LocoLoading');
			this.ajaxClass.AjaxGetNextLevel(
					this.objectName,
					level,
					select.val(),
					this.metaData,
					lc$.Ajax.callback);
		}
		this._refreshSelectedValues();
	},
	onChangeCallback: function(level, values) {
		if (level >= this.selectElements.length)
			return;
		var select = $(this.selectElements[level]);
		select.removeClass('LocoLoading');
		if (values.length == 0)
			return;
		select.enable();
		select.empty();
		if (this.selectMode == 'ShowSelectCaption')
			select.addOption('', this.selectCaption);
		for (var i = 0; i < values.length; i++)
			select.addOption(values[i].Value, values[i].Text);
		this.onChange(select);
		this._refreshSelectedValues();
	}
}
//End LocoHierarchySelector
//BasicDataSelector
function LocoBasicDataSelector(o) {
	this.dataTypeId = '';
	this.selector = null;
	$.extend(this, o);
}
LocoBasicDataSelector.prototype = {
	setDataType: function(dataTypeId, callback) {
		if (this.dataTypeId == dataTypeId)
			return;
		this.dataTypeId = dataTypeId;
		this.selector.changeMetaData(dataTypeId + ',' + this.selector.metaData.split(',')[1], callback)
	},
	setSelectedValues: function(values) {
		this.selector.setSelectedValues(values);
	},
	getSelectedValues: function() {
		return this.selector.getSelectedValues();
	}
}
//End BasicDataSelector
//CategoryHirearchySelector
function CategoryHirearchySelector(o) {
	this.rootCategoryId = '';
	this.selector = null;
	$.extend(this, o);
}
CategoryHirearchySelector.prototype = {
	setRootCategory: function(rootCategoryId, levelTitles, callback) {
		if (this.rootCategoryId == rootCategoryId)
			return;
		this.rootCategoryId = rootCategoryId;
		this.selector.changeMetaData(rootCategoryId + ',' + levelTitles, callback)
	},
	setSelectedValues: function(values) {
		this.selector.setSelectedValues(values);
	},
	getSelectedValues: function() {
		return this.selector.getSelectedValues();
	}
}
//End CategoryHirearchySelector
//end controls
/*Hierarchy Selector*/
function HierarchySelector_ToggleSelect(idPrefix, element, title, value, maxItems) {
	var valuesElement = document.getElementById(idPrefix + 'SelectedValuesHiddenField');
	var titlesElement = document.getElementById(idPrefix + 'SelectedTitlesHiddenField');
	var values = valuesElement.value.split('$');
	var titles = titlesElement.value.split('$');

	if (element.className == 'lcb-off') {
		if (maxItems > 0 && values.length > maxItems)
			return;
		element.className = 'lcb-on';
		valuesElement.value += '$' + value;
		titlesElement.value += '$' + title;
	}
	else {
		element.className = 'lcb-off';
		valuesElement.value = '';
		titlesElement.value = '';
		for (var index = 0; index < values.length; index++) {
			if (values[index] != value) {
				valuesElement.value += '$' + values[index];
				titlesElement.value += '$' + titles[index];
			}
		}
		valuesElement.value = valuesElement.value.substring(1, valuesElement.value.length);
		titlesElement.value = titlesElement.value.substring(1, titlesElement.value.length);
	}
}

/*End Hierarchy Selector*/
var Loco = Loco || {};
Loco.$ = loco$;
$.extend(Loco, lc$);
var LocoPager = lc$.Pager;
var LocoAjax = LocoAjax || {};
$.extend(LocoAjax, lc$.Ajax);
var AjaxList = Array;
Loco.EmptyGuid = '00000000-0000-0000-0000-000000000000';
Loco.Navigation = lc$.Nav;
Loco.Util = {
	selectedClass: 'ajax-selected',
	extend: $.extend,
	getUnique: function() { return lc$.uid(); },
	_removeNull: function(arr){
		if(!arr) return $();
		var res = [];
		for(var i=0; i<arr.length; i++)
			if(arr[i])
				res.push(arr[i]);
		return $(res);
	},
	attach: function(el, eventType, fn) {
		eventType = [].concat(eventType).join(' ');
		Loco.Util._removeNull($(el)).on(eventType, fn);
	},
	dispatch: function(el, eventType, args) { Loco.Util._removeNull($(el)).trigger(eventType, args) },
	setAttribute: function(el, attr, value) { Loco.Util._removeNull($(el)).attr(attr, value) },
	removeAttribute: function(el, attr) { Loco.Util._removeNull($(el)).removeAttr(attr) },
	hasClass: function(el, className) { return Loco.Util._removeNull($(el)).hasClass(className) },
	addClass: function(el, className) { Loco.Util._removeNull($(el)).addClass(className) },
	removeClass: function(el, className) { Loco.Util._removeNull($(el)).removeClass(className) },
	getEvent: function(e) { return e || window.event; },
	cancelBubble: function(e) { e = Loco.Util.getEvent(e); if (e) { e.cancelBubble = true; if (e.stopPropagation) e.stopPropagation(); } },
	getTarget: function(e) { return $(e.target)[0] },
	toElement: function(html, parentNode) { var el = $(html); $(parentNode).append(el); return el[0] },
	flash: function(el, o) { Loco.Util._removeNull($(el)).flashClass(o.className, o.time) },
	enable: function(el) { Loco.Util._removeNull($(el)).enable(); Loco.Util._removeNull($(el)).removeClass('LocoDisabled') },
	disable: function(el) { Loco.Util._removeNull($(el)).disable(); Loco.Util._removeNull($(el)).addClass('LocoDisabled') },
	isDisabled: function(el) { return Loco.Util._removeNull($(el)).prop('disabled') == true },
	show: function(el) { Loco.Util._removeNull($(el)).removeClass('LocoHide'); Loco.Util._removeNull($(el)).show() },
	hide: function(el) { Loco.Util._removeNull($(el)).addClass('LocoHide'); Loco.Util._removeNull($(el)).hide() },
	showElement: function(id) { Loco.Util.show(loco$(id)) },
	hideElement: function(id) { Loco.Util.hide(loco$(id)) },
	setStyles: function(el, styles) { for (var s in styles) Loco.Util._removeNull($(el)).css(s, styles[s]) },
	getByTagName: function(el, tagName) { return Loco.Util._removeNull($(el)).find(tagName) },
	remove: function(el) { Loco.Util._removeNull($(el)).remove() },
	setText: function(el, text) { Loco.Util._removeNull($(el)).text(text) },
	setValue: function(el, value) { Loco.Util._removeNull($(el)).setValue(value) },
	getValue: function(el, valueType, ignoreFormat) { return Loco.Util._removeNull($(el)).getValue(valueType, ignoreFormat) },
	getByClass: function(el, className) { return Loco.Util._removeNull($(el)).find('.' + className) },
	getByAttr: function(el, attr, value) {
		if (value)
			return Loco.Util._removeNull($(el)).find('[' + attr + '=' + value + ']')
		else
			return Loco.Util._removeNull($(el)).find('[' + attr + ']')
	},
	indexOf: function(arr, elt, from) { return arr.indexOf(elt, from); },
	create: function(tagName, innerHTML, attributes, parnetNode) {
		var el = document.createElement(tagName);
		el.innerHTML = innerHTML;
		for (var attr in attributes) {
			if (attr == 'className')
				el.className = attributes['className'];
			else
				el.setAttribute(attr, attributes[attr]);
		}
		if (parnetNode)
			parnetNode.appendChild(el);
		return el;
	},
	obj2url: function(obj, temp, prefixDone) {
		var uristrings = [],
			prefix = '&',
      add = function(nextObj, i) {
      	var nextTemp = temp
					? (/\[\]$/.test(temp)) // prevent double-encoding
          ? temp
          : temp + '[' + i + ']'
          : i;
      	if ((nextTemp != 'undefined') && (i != 'undefined')) {
      		uristrings.push(
						(typeof nextObj === 'object')
							? Loco.Util.obj2url(nextObj, nextTemp, true)
              : (Object.prototype.toString.call(nextObj) === '[object Function]')
              ? encodeURIComponent(nextTemp) + '=' + encodeURIComponent(nextObj())
              : encodeURIComponent(nextTemp) + '=' + encodeURIComponent(nextObj)
             );
      	}
      };
		if (!prefixDone && temp) {
			prefix = (/\?/.test(temp)) ? (/\?$/.test(temp)) ? '' : '&' : '?';
			uristrings.push(temp);
			uristrings.push(Loco.Util.obj2url(obj));
		} else if ((Object.prototype.toString.call(obj) === '[object Array]') && (typeof obj != 'undefined')) {
			for (var i = 0, len = obj.length; i < len; ++i)
				add(obj[i], i);
		} else if ((typeof obj != 'undefined') && (obj !== null) && (typeof obj === "object")) {
			for (var i in obj)
				add(obj[i], i);
		} else {
			uristrings.push(encodeURIComponent(temp) + '=' + encodeURIComponent(obj));
		}

		return uristrings.join(prefix)
                     .replace(/^&/, '')
                     .replace(/%20/g, '+');
	},
	getEmailProvider: function(email) {
		var emailProvider = 'unknown';
		if (!email || email.indexOf('@') <= 0)
			return emailProvider;
		var providerName = email.toLowerCase().split('@')[1].split('.')[0];
		switch (providerName) {
			case 'gmail':
				emailProvider = 'gmail';
				break;
			case 'yahoo':
				emailProvider = 'yahoo';
				break;
			case 'hotmail':
				emailProvider = 'hotmail';
				break;
		}

		return emailProvider;
	},
	setValidation: function(el, o) {
		var options = {
			isrequired: 'true',
			requiredmessage: '*',
			validationgroup: '',
			formatmessage: ''
		};
		$.extend(options, o);
		for (var p in options)
			Loco.Util._removeNull($(el)).attr(p, options[p]);
	},
	shuffleChildren: function(container) { $(container).shuffle() }
};
Loco.Util.validate = lc$.Validation.validate;
Loco.Util.clearValidate = lc$.Validation.clear;
$.extend(LocoAjax, Loco.Util);
//end Loco.Util

lc$.Dic = function(list, keyName) {
	if (list && list.length && keyName && keyName != '')
		for (var i = 0; i < list.length; i++)
		this.add(list[i][keyName], list[i]);
}
lc$.Dic.prototype = {
	add: function(key, o) {
		this['_m_' + key] = o;
	},
	remove: function(key) {
		delete this['_m_' + key];
	},
	getValue: function(key) {
		return this['_m_' + key];
	},
	hasValue: function(key) {
		return this.hasOwnProperty('_m_' + key);
	},
	getKeys: function() {
		var res = new Array();
		for (var p in this)
			if (p.substring(0, 3) == '_m_')
			res.push(p.substring(3, p.length));
		return res;
	},
	getValues: function() {
		var res = new Array();
		for (var p in this)
			if (p.substring(0, 3) == '_m_')
			res.push(this[p]);
		return res;
	},
	getLength: function() {
		return this.getValues().length;
	},
	clear: function() {
		var keys = this.getKeys();
		for (var i = 0; i < keys.length; i++)
			this.remove(keys[i]);
	}
}
//end lc$.Dic
var LocoDic = lc$.Dic;
AjaxList = function(allowDuplicate) {
	this.allowDuplicate = false;
	if (allowDuplicate)
		this.allowDuplicate = allowDuplicate;
	this.items = [];
	this.len = function() { return this.items.length; };
	this.remove = function(item) {
		this.removeAt(this.indexOf(item));
	};
	this.removeAt = function(index) {
		if (index < 0 || index > this.len - 1)
			return;
		this.items.splice(index, 1);
	};
	this.add = function(item) {
		if (!this.allowDuplicate)
			this.remove(item);
		this.items.push(item);
	};
	this.find = function(item) {
		return (this.indexOf(item) != -1);
	};
	this.indexOf = function(item) {
		var i = 0;
		while (i < this.items.length)
			if (this.items[i] == item) { return i; } else { i++; }

		return -1;
	};
	this.toStr = function() {
		return this.items.toString();
	};
	this.clear = function() {
		return this.items = [];
	};
}
function AjaxDic() {
	this.keys = new AjaxList();
	this.values = new AjaxList(true);
	this.len = function() { return this.keys.len(); };
	this.clear = function() { this.keys.clear(); this.values.clear(); };
	this.add = function(key, value) {
		//alert(key + ':' + value);
		this.keys.add(key);
		this.values.add(value);
	};
	this.remove = function(key) {
		var index = this.keys.indexOf(key);
		if (index != -1) {
			this.keys.removeAt(index);
			this.values.removeAt(index);
		}
	};
	this.getValue = function(key) {
		var index = this.keys.indexOf(key);
		if (index != -1) {
			return this.values.items[index];
		}
		return null;
	};
	this.setValue = function(key, value) {
		var index = this.keys.indexOf(key);
		if (index != -1)
			this.values.items[index] = value;
		else {
			this.add(key, value);
		}
		var index = this.keys.indexOf(key);
	};
}
