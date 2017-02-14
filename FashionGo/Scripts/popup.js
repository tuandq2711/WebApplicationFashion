function cpu_validateEmail(email) { 
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
	return re.test(email);
} 


jQuery(document).ready( function($) {
	var contact_form_height = $('#contact_form_container').height() + 30;
	$('#contact_popup').css('height', contact_form_height + 'px');
	$('#contact_popup').css('bottom', '-' + (contact_form_height+8) + 'px');

	$('#popup-submit-button').click(function() {
	/*		if($('#contact_form_name').val() == "") {
			$('#contact_form_name').focus();
			alert('Please enter your name!');
			return false;
		}
		
	if($('#contact_form_email').val() == "") {
			$('#contact_form_email').focus();
			alert('Please enter your email!');
			return false;
		}
		
		if(!cpu_validateEmail($('#contact_form_email').val())) {
			$('#contact_form_email').focus();
			alert('Please enter a VALID email!');
			return false;
		}
		
		if($('#contact_form_message').val() == "") {
			$('#contact_form_message').focus();
			alert('Please enter your message!');
			return false;
		}*/

		var returnFunction = function(json) {
			if(json.success) {
				$('#contact_form_container').hide();
				$('#contact_message_sent').show();
				contact_form_height = $('#contact_message_sent').height() + 10;
				$('#contact_popup').animate({'height': contact_form_height + 'px'});
			} else {
				$('#contact_message_error').show();
				$('#contact_message_error').html(json.message);
				console.log($('#contact_message_error').html());
				contact_form_height = $('#contact_message_error').height() + $('#contact_form_container').height() + 10;
				$('#contact_popup').animate({'height': contact_form_height + 'px'});
			}
		};

		$.ajax({ type: "post",
			url: ContactPopup.ajaxurl,
			data: $("#contact_popup_form").serialize(),
			dataType: "json",
			success: returnFunction,
			error: returnFunction
		});


		return false;
	}
	);
	$('#contact_header').click(
		function() {

			if($('#contact_popup').css('bottom') == "0" || $('#contact_popup').css('bottom') == "0px") {
				$('#contact_popup').animate({'bottom': '-'+(contact_form_height+8)+'px'});
			}else{
				$('#contact_popup').animate({'bottom': '0'});
			//	$('#contact_form_name').focus();

			}
		});

} );