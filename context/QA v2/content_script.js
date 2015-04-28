/*!
 * jQuery UI Widget-factory plugin boilerplate (for 1.8/9+)
 * Author: @addyosmani
 * Further changes: @peolanha
 * Licensed under the MIT license
 */

/*
todo:
- highlight phrases in paragraphs
- mouseover highlight

*/


;(function ( $, window, document, undefined ) {

    // define your widget under a namespace of your choice
    //  with additional parameters e.g.
    // $.widget( "namespace.widgetname", (optional) - an
    // existing widget prototype to inherit from, an object
    // literal to become the widget's prototype );

	// Let's add an ID number to each paragraph.
	$("#story p").each(function(index) {
		$(this).attr("id", index);
	})


	var json;
	$.get("http://localhost:8080/todos").done(function(data) {
		json = data;
		$.each(data, function(index, value) {
            if (value != null) {
    			$("p#" + index).response({data: value});
            }
		})
	});


    $.widget( "ui.response" , {

        //Options to be used as defaults
        options: {
        	data: null
        },

        //Setup widget (eg. element creation, apply theming
        // , bind events etc.)
        _create: function () {
            if (this.options.data != null) {
                            this.createElements();
            this.setCSS();
            this.blastText();

            this._on(this.elButton, {
                click: "toggleDisplay",
                // mouseenter: "toggleButtonHighlight",
                mouseenter: "highlightPhrases",
                // mouseleave: "toggleButtonHighlight",
                mouseleave: "highlightPhrases"
            });

            this._on($(".phrase"), {
                mouseenter:"toggleButtonHighlight"
            })


            var $elContainer = this.elContainer; // Otherwise we lose the context of "this"

            if (this.options.data !== null) {
                this.elContainer.append("<h3>Your Questions, Answered</h3><br/>")
                $.each(this.options.data, function(index, value) {
                    var dashedPhrase = index.replace(/\s/g, "-");
                    // Get the phrase that the response is about.
                    var str = "<div>"

                    // Get the question type, answer, etc.
                    $.each(value, function(i, v) {
                        str += "<p class='phrase " + dashedPhrase + "'>" + index + "<span> | " + i + "?</span></p><p class='answer'>" + v["answer"] + "</p><p class='author'>Answered by " + v["author"] + "</p></div>"
                
                    })
                    $(str).appendTo($elContainer);

                    $(".phrase." + dashedPhrase).on("mouseenter", function() {
                        $(this).addClass('highlight');
                        $(".blast." + dashedPhrase).addClass('highlight');
                    })
                    $(".phrase." + dashedPhrase).on("mouseout", function() {
                        $(this).removeClass('highlight');
                        $(".blast." + dashedPhrase).removeClass('highlight');
                    })


                })
            }

            }



            // _create will automatically run the first time
            // this widget is called. Put the initial widget
            // setup code here, then you can access the element
            // on which the widget was called via this.element.
            // The options defined above can be accessed
            // via this.options this.element.addStuff();
        },

        highlightPhrases: function(event) {
        	if (event.type == "mouseenter") {
	        	$(this.element).children(".blast").addClass('highlight-hover')
        	} else {
	        	$(this.element).children(".blast").removeClass('highlight-hover')
        	}
        },

        blastText: function() {
        	if (this.options.data == null) return;

			$this = $(this.element);
        	$.each(this.options.data, function(index, value) {
        		var dashedPhrase = index.replace(/\s/g, "-");
        		$this.blast({
					tag: "span",
					search: index,
					customClass: dashedPhrase,
					returnGenerated: true
				})
        	})
        },

        getSum: function() {
        	if (this.options.data != null) {
	        	var keys = Object.keys(this.options.data);
	        	return Object.keys(this.options.data).length;
		    }
        },

        createElements: function() {
        	this.elContainer = $("<div class='response-container'></div>").appendTo($(this.element));
        	this.elButton = $("<a class='response-icon' href='#'><img class='response-icon' src='" + chrome.extension.getURL('noun_65537_cc.svg') + "'></a>").appendTo($(this.element));
        },

        setCSS: function() {
        	this.elButton.css({
        		"position" : "absolute",
        		"top" : $(this.element).offset().top - $(this.element).height()/2 + 8 + "px",
        		"left" : "61%",
        	})

            this.elContainer.css({
                "display" : "none",
                "top" : $(this.elButton).css("top"),
            })
        },

        // Destroy an instantiated plugin and clean up
        // modifications the widget has made to the DOM
        destroy: function () {

            // this.element.removeStuff();
            // For UI 1.8, destroy must be invoked from the
            // base widget
            $.Widget.prototype.destroy.call(this);
            // For UI 1.9, define _destroy instead and don't
            // worry about
            // calling the base widget
        },

        toggleDisplay: function(event) {
        	$(".response-container").toggle(false);
        	$(".blast.visible").removeClass("visible");
        	$(".button-active").removeClass("button-active")

        	this.element.children(".blast").addClass("visible")
        	this.elButton.addClass('button-active')
        	this.elContainer.toggle();
        	event.preventDefault();
        },

        methodB: function ( event ) {
            //_trigger dispatches callbacks the plugin user
            // can subscribe to
            // signature: _trigger( "callbackName" , [eventObject],
            // [uiObject] )
            // eg. this._trigger( "hover", e /*where e.type ==
            // "mouseenter"*/, { hovered: $(e.target)});
            console.log("methodB called");
        },

        methodA: function ( event ) {
            this._trigger("dataChanged", event, {
                key: "someValue"
            });
        },

        // Respond to any changes the user makes to the
        // option method
        _setOption: function ( key, value ) {
            switch (key) {
            case "someValue":
                //this.options.someValue = doSomethingWith( value );
                break;
            default:
                //this.options[ key ] = value;
                break;
            }

            // For UI 1.8, _setOption must be manually invoked
            // from the base widget
            $.Widget.prototype._setOption.apply( this, arguments );
            // For UI 1.9 the _super method can be used instead
            // this._super( "_setOption", key, value );
        }
    });

	$("#story").response();

	$.widget( "ui.question" , {

        //Options to be used as defaults
        options: {
            phrase: null,
        },

        //Setup widget (eg. element creation, apply theming
        // , bind events etc.)
        _create: function () {
        	if ($(".popover").length > 0) return;
        	this.createPopover();
            // _create will automatically run the first time
            // this widget is called. Put the initial widget
            // setup code here, then you can access the element
            // on which the widget was called via this.element.
            // The options defined above can be accessed
            // via this.options this.element.addStuff();
        },

        createPopover: function() {
        	this.elPopover = this.element.popover({
        		content: "<select><option value='Who?'>Who?</option><option value='What?'>What?</option><option value='Where?'>Where?</option><option value='When?'>When?</option><option value='Why?'>Why?</option></select><button type='button' class='blast-button'>submit</button>",
        		placement: "right",
        		title: "Ask a question about this",
        		html:true,
        	}).popover('show')

        	this.elPopoverDiv = $("#" + this.elPopover.attr('aria-describedby'));
        	this.elPopoverTitle = this.elPopoverDiv.find(".popover-title").first();
        	this.elPopoverContent = this.elPopoverDiv.find(".popover-content").first();
			this.elPopoverButton = this.elPopoverDiv.find(".blast-button").first();

        	this._on(this.elPopoverButton, {
        		"click" : "dismissPopover"
        	})

        },

        dismissPopover: function() {
        	$(this.element).addClass("just-asked")
        	this.elPopoverButton.unbind();
        	this.elPopoverTitle.text("Question submitted");
        	this.elPopoverContent.text("We have submitted your question. You will receive an email notification if your question is answered.");
        	this.elPopoverDiv.css({
        		"margin-top" : -this.elPopoverContent.height()/2 + 12
        	});

        	$this = this;
			setTimeout(function() {
				$this.elPopoverDiv.fadeOut(1000, function(){
					$(this).remove()
				})
			}, 2500);

        },

        // Destroy an instantiated plugin and clean up
        // modifications the widget has made to the DOM
        destroy: function () {

            // this.element.removeStuff();
            // For UI 1.8, destroy must be invoked from the
            // base widget
            $.Widget.prototype.destroy.call(this);
            // For UI 1.9, define _destroy instead and don't
            // worry about
            // calling the base widget
        },

        methodB: function ( event ) {
            //_trigger dispatches callbacks the plugin user
            // can subscribe to
            // signature: _trigger( "callbackName" , [eventObject],
            // [uiObject] )
            // eg. this._trigger( "hover", e /*where e.type ==
            // "mouseenter"*/, { hovered: $(e.target)});
            console.log("methodB called");
        },

        methodA: function ( event ) {
            this._trigger("dataChanged", event, {
                key: "someValue"
            });
        },

        // Respond to any changes the user makes to the
        // option method
        _setOption: function ( key, value ) {
            switch (key) {
            case "someValue":
                //this.options.someValue = doSomethingWith( value );
                break;
            default:
                //this.options[ key ] = value;
                break;
            }

            // For UI 1.8, _setOption must be manually invoked
            // from the base widget
            $.Widget.prototype._setOption.apply( this, arguments );
            // For UI 1.9 the _super method can be used instead
            // this._super( "_setOption", key, value );
        }
    });

	$(document).mouseup(function(e) {
		var str = window.getSelection().toString();
		if (str != "") {
			var span = document.createElement("span");
			var sel = window.getSelection();
			var range = sel.getRangeAt(0).cloneRange();
			range.surroundContents(span);
			sel.removeAllRanges();
			sel.addRange(range);

			$(span).question({phrase: str});
		}
	});





})( jQuery, window, document );

