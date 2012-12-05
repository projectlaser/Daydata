this.launch = function () {
    var tileDiv = $('#' + self.uniqueId);

    // Make the tileDIv explode into full screen
    var clone = $("<div/>")
    // .addClass(self.tileClasses())
            .css({
                'position': 'absolute',
                'left': tileDiv.offset().left,
                'top': tileDiv.offset().top,
                'width': tileDiv.width() + "px",
                'height': tileDiv.height() + "px",
                'z-index': 1500
            })
            .appendTo(document.body)
            .animate({
                left: $(window).scrollLeft(),
                top: $(window).scrollTop(),
                width: "100%",
                height: "100%"
            }, 500, function () {
                // Launch the full screen app inside an IFRAME. ViewModel has
                // this feature.
                launchApp('test', 'apptitle', 'http://project-laser.com', function () { clone.fadeOut(); });
            })
            .append(
                $('<img />')
                    .attr('src', self.appIcon)
                    .addClass(self.iconClasses())
                    .css({
                        'position': 'absolute',
                        'left': ($(window).width() - 512) / 2,
                        'top': ($(window).height() - 512) / 2
                    })
            );
}
function launchApp(id, title, url, loaded) {

    //self.hideMetroSections();

   /// self.appRunning = true;
   // self.currentApp = url;

    var iframe = $('<iframe id="' + 1 + '" frameborder="no" />')
           .css({
               'position': 'absolute',
               'left': "0",
               'top': "0px",
               'width': '100%',
               'height': '100%',
               'z-index': 1500,
               'visibility': 'hidden',
               'background-color': 'white'
           })
           .appendTo(document.body)
           .attr({ 'src': url })
           .load(function () {
              // self.hideNavBar();
           //    loaded();
               $(this).css('visibility', 'visible');
           });
}