$(function () {
    $.simpleWeather({
        zipcode: '51501',
        unit: 'f',
        success: function (weather) {
            $("#weatherImg").append('<h2>' + weather.city + '</h2>');
            $("#weatherImg").append('<img style="width="125px" src="' + weather.image + '">');
            $("#weatherImg").append('<p>' + weather.temp + '&deg; ' + weather.units.temp + '<br /><span>' + weather.currently + '</span></p>');

        },
        error: function (error) {
            console.write(error);
        }
    });
    $(".tile").each(function () {
 /**       $(this).click(function () {
            var url = $(this).attr("url");
            var iconSrc = $(this).attr("iconSrc");
            var unid = $(this).attr("unid");
            var classes = $(this).attr("class");
            var iconclasses = $(this).attr("iconclasses");
            launch(url, iconSrc, unid, classes, iconclasses);
        });**/

    });

});


function change(url) {
        linkLocation = this.href;
        $("body").fadeOut(1000, redirectPage);      
         

}
    function redirectPage() {
        window.location = linkLocation;
    }

function launch(url, iconSrc, id, classes, iconclasses) {
    var tileDiv = $('#' + id);
    var clone = $("<div/>")
    .addClass(classes)
    .css({
        'position': 'absolute',
        'left': tileDiv.offset().left,
        'top': tileDiv.offset().top,
        'width': tileDiv.width() + "px",
        'height': tileDiv.height() + "px",
        'z-index': '65000'
    }).appendTo(document.body).animate({
        left: $(window).scrollLeft(),
        top: $(window).scrollTop(),
        width: "100%",
        height: "100%"
    }, 500, function () {
        launchApp(id, '', url, function () {
            clone.fadeOut();
        });
    })
   



}

function launchApp(id, title, url, loaded) {
    var iframe = $('<iframe id="' + id + '" frameborder="no" />')
           .css({
               'position': 'absolute',
               'left': "0",
               'top': "0px",
               'width': '100%',
               'height': '100%',
               'z-index': '60000',
               'visibility': 'hidden',
               'background-color': 'white'
           })
           .appendTo(document.body)
     .attr({ 'src': url })
           .load(function () {
               hideBar();
               $(this).css('visibility', 'visible');
           });

       }
       function hideBar() {
           var navbar = $("#top_nav");
           navbar
            .css("z-index", 60001)
            .delay(3000)
            .animate({
                top: -(navbar.height() - 5) + "px"
            }, function () {
                $('#top_nav').tipsy();
                _.delay(function () {
                    $('#top_nav').tooltip('hide');
                }, 10000);
            }).bind("mouseenter click", function () {
                navbar
                    .stop(true, true)
                    .animate({
                        top: "0px"
                    });
            }).bind("mouseleave", function () {
                navbar
                    .stop(true, true)
                    .delay(3000)
                    .animate({
                        top: -(navbar.height() - 5) + "px"
                    });
            });
       
       }