function View2(n)
	{
		var b = "#" + n + "1";
		var x = $("#" + n).position();
		if($(b).height()<=57)
		{
		    $(b).stop();
			//$(b).animate({ "top": "=116.33334350585938px" }, { duration: 200, queue: false } , "slow" );
		    //$(b).animate({ "height": "=17px" } ,{ duration: 200, queue: false }, "slow" );
		    var nTop = x.top + 72;
		    $(b).height('17px');
		    $(b).css({ top: '116.33334350585938px' });
			var c = "#" + n +2;
			$(c).css('visibility','hidden');
		}
	}
function View1(n)
	{
		var b = "#" + n + "1";
		var x = $(b).position();
		if($(b).height()==17)
		{
		    $(b).stop();
			$(b).animate({ "top": "-=40px" }, { duration: 200, queue: false } , "slow" );
			$(b).animate({ "height": "+=40px" } ,{ duration: 200, queue: false }, "slow" );
			var c = "#" + n +2;
			$(c).css('visibility','visible');
		}
	}
function ShowTop(n)
	{
		var b = "#" + n + "1";
		var x = $(b).position();
		alert($(b).height());
	}