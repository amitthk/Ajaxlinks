  // JScript File
// AjaxLinks loads a link into a modular dialog instead of directly opening it.
//Usage is simple. Just add the class="AjaxGet" to your hyperlink.
//To make a form AjaxPostable add the class="AjaxPost" to your form.
// Reference : Amit Kumar Thakur post:(http://www.codeproject.com/Articles/341151/Simple-Ajax-Post-Form-and-Ajax-Fetch-Link-to-Modal)
// JavaScript Document<script type="text/javascript">
<!--
var AjaxLinks =
{
screenWidth:0,
screenHeight:0,
postResponseDivParam:{modal:true},
init: function()
{
//this.LoadMenu();
this.SetSize();
this.AjaxGetLink();
this.AjaxPostForm();
},
LoadMenu: function()
{
//Can be used to load the menu. Not used now because our menu is just one link.
var strMenuLnk = "menu.htm?bustcache="+ new Date().getTime();
	$.get(strMenuLnk, function(data) {
  $('#menu').html(data);
	});
},
SetSize: function() {
  var myWidth = 0, myHeight = 0;
  if( typeof( window.innerWidth ) == 'number' ) {
    //Non-IE
    myWidth = window.innerWidth;
    myHeight = window.innerHeight;
  } else if( document.documentElement && ( document.documentElement.clientWidth || document.documentElement.clientHeight ) ) {
    //IE 6+ in 'standards compliant mode'
    myWidth = document.documentElement.clientWidth;
    myHeight = document.documentElement.clientHeight;
  } else if( document.body && ( document.body.clientWidth || document.body.clientHeight ) ) {
    //IE 4 compatible
    myWidth = document.body.clientWidth;
    myHeight = document.body.clientHeight;
  }
  screenWidth=myWidth;
  screenHeight=myHeight;
  //window.alert( 'Width = ' + myWidth );
  //window.alert( 'Height = ' + myHeight );
},
AjaxGetLink: function() 
{
        $('a.AjaxGet').click(function () {
            var pdata = $(this).attr('data-value');
			
            //Create an empty dialog first. This will be destroyed once data is received
            var $divNm = $('<div>Loading. Please wait....</div>').appendTo($(this)).dialog();//.dialog(modalOptions); //'#' + $(this).attr('data-name');            
            var actionurl = $(this).attr('href');
			
            var horizontalCenter = Math.floor(screenWidth/2);
            var verticalCener = Math.floor(screenHeight/2);

            //Setting the position and width of the 
            //Popup dialog to open to display response once contents of target Link are fetched using Ajax
            var myDialogX = 20; 
            var myDialogY = verticalCener-300; 
            var modalWidth = screenWidth -80;

			var modalOptions = { height:600, width: modalWidth, autoOpen: true, modal: true, zIndex: 3999, position: [myDialogX,myDialogY],buttons: {Close: function() {$( this ).dialog( "close" );}}  };
			
            var dialogOpts = {
                type: "GET",
                url: actionurl+"?bustcache="+ new Date().getTime(),
                data: pdata,
                success: function (resp) {
                //Upon success, load the fetched data into the display Div and create a Modal Dialog for it.
                    $divNm.html(resp);
					$divNm.dialog("destroy");
                    $divNm.dialog(modalOptions);
					return false;
                },
                error: function (xhr, status, error) {
                    $divNm.html(xhr.responseText + status.toString());
					$divNm.dialog("destroy");
                    $divNm.dialog(modalOptions);
					return false;
                }
            };
            $.ajax(dialogOpts);
            return false;
        });
    },
	AjaxPostForm: function () {
        /* attach a submit handler to the form */
        $("form.AjaxPost").submit(function (event) {

            /* stop form from submitting normally */
            event.preventDefault();

            /* get some values from elements on the page: */
            var $form = $(this);


            //Gets the target of the form. And Serialize Form data so that it can be posted using Ajax
            var url = $form.attr('action');
            var pdata = $form.serialize()


            $.ajax({
                type: "POST",
                url: url,
                data: pdata,
                success: function (resp) {
                //Upon success, load the response of the Posted form into the display Div and create a Modal Dialog for it.
                    var $jAlrtSuccess = $('<div />');
                    $jAlrtSuccess.html(resp);
                    $($jAlrtSuccess).dialog(AjaxLinks.postResponseDivParam);
                },
                error: function (xhr, status, error) {
                    var $jAlrtError = $('<div>' + xhr + '</div>');
                    $($jAlrtError).dialog(AjaxLinks.postResponseDivParam);
                }
            });
        });
        return false;
    },
    parseData: function(data,hdrRow) { //For Basic parsing of response JSON data. Displays the JSON response as a table.
        var respHtm = '<table class="tblAllBorders">'+hdrRow; //Add a header row if needed.
        $.each(data, function (i, object) {
            respHtm = respHtm + '<tr>';
            $.each(object, function (j, field) {
                respHtm = respHtm + '<td>' + field + '</td>';
            });
            respHtm = respHtm + '</tr>';
        });
        respHtm = respHtm + '</table>';
        return respHtm;
    }
	};
$(document).ready(function ($) {
	AjaxLinks.init();
});
-->