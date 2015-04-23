$(document).ready(function() {

	//Size the cards correctly
	$( ".cards" ).each(function( index ) {
	  var numCards = $(this).children('li').length;
	  var totalWidth = numCards * 100;
	  var itemWidth = 100 / numCards;
	  $(this).css('width',totalWidth+'%');
	  $(this).children('li').css('width', itemWidth+'%');
	  for (var i=0; i<numCards; i++) {
	  	$(this).siblings('.dots').append('<span class="dot"> &bull; </span>');
	  }
	});

	//Handle a click on a link
	$('a').on('click', function() {
		var parentEl = $(this).parent();
		var thisIndex = $(parentEl).children('a').index(this);
		var targetPara = $('#' + String($(parentEl).attr('id'))+'-context');
		var targetGroup = $('#' + String($(parentEl).attr('id'))+'-context').children('ul');
		
		$(parentEl).children('a').removeClass('selected');
		$(this).addClass('selected');

		$(targetPara).slideDown('normal', function() {
			var targetWidth = $($(targetGroup).children('li')[0]).width();
			var x = 0-(targetWidth*thisIndex);

			$(targetGroup).animate({
			   left: x,
			}, 600, function() {
				$(targetGroup).siblings('.dots').children('.dot').css('opacity','0.4');
				$($(targetGroup).siblings('.dots').children('.dot')[thisIndex]).css('opacity','1');
			});
		});
		var dotsH = $(targetGroup).siblings('.dots').height();
		var cardH = $($(targetGroup).children('li')[thisIndex]).height();
		$(targetPara).animate({
		   height: cardH,
		}, 600);

		
	})

	//Handle a click on a dot
	$('.dot').on('click', function() {
		var thisIndex = $(this).parent().children('.dot').index(this);
		console.log($($(this).parent().parent().prev('p').children('a')[thisIndex]))
		$($(this).parent().parent().prev('p').children('a')[thisIndex]).trigger('click');
	})

	//Handle a click on the close button
	$('.close').on('click', function() {
		$(this).parent().slideUp();
		$(this).parent().prev('p').children('a').removeClass('selected');
	})
})