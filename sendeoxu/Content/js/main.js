
$(document).ready(function(){
    //reting user slider
    $('.owl-carousel').owlCarousel({
        responsive: {
            0: {
                items: 1
            },
            600: {
                items:1
            },
            1000: {
                items: 1
            }
        }
    });
});

// scroll top start
    (function() {
        var link,
            toggleScrollToTop = function() {
                if ($('body').scrollTop() > 0 || $('html').scrollTop() > 0) {
                    link.fadeIn(400);
                } else {
                    link.fadeOut(400);
                }
            }
        $(document).ready(function() {
            link = $('.scroll-top');
            $(window).scroll(toggleScrollToTop);

            toggleScrollToTop();
        });
    })();
    // scroll top end


//profil sign-in start
// Get the modal
var modal = document.getElementById('profil-Modal');
// Get the button that opens the modal
var btn = document.getElementById("btn-profil");
// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];
// When the user clicks the button, open the modal 
btn.onclick = function() {
    modal.style.display = "block";
}
// When the user clicks on <span> (x), close the modal
span.onclick = function() {
    modal.style.display = "none";
}
// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
//profil sign-in end