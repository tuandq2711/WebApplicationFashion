!function($){
	$(document).ready( function() {
		$('#cpanel_btn').click( function() {
			if ($('#cpanel_btn i').attr('class') == 'icon-cog') {
				$('#cpanel_wrapper').animate( {
					'right' : '-300px'
				}, 200, function() {
					$('#cpanel_wrapper').show().animate( {
						'right' : '0px'
					});
				});
				$('#cpanel_btn i').attr('class', 'icon-hand-right');
			} else if ($('#cpanel_btn i').attr('class') == 'icon-hand-right') {
				$('#cpanel_wrapper').animate( {
					'right' : '0px'
				}, 200, function() {
					$('#cpanel_wrapper').show().animate( {
						'right' : '-300px'
					});
				});
				$('#cpanel_btn i').attr('class', 'icon-cog');
			}
		});
	});
	$(document).ready( function() {
		$('.theme-color').click( function() {
			$('#os_theme').attr('value',$(this).attr('title'));
		});
	});
}(jQuery);