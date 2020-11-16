
function hide() {
	var pa = window.document.getElementById("panier").style.visibility
	if (pa == "visible") {
		window.document.getElementById("panier").style.visibility = "hidden"
	}
}


function myclick2() {


	var pa = window.document.getElementById("panier").style.visibility

	if (pa == "visible") {
		window.document.getElementById("panier").style.visibility = "hidden"
	}

	else {
		window.document.getElementById("panier").style.visibility = "visible"
	}
	
}

	
var imgs = ["/Image/Slide/livre1.jpg", "/Image/Slide/livre2.jpg", "/Image/Slide/livre3.jpg", "/Image/Slide/livre4.jpg", "/Image/Slide/livre5.jpg", "/Image/Slide/livre6.jpg"]

var k = 0
function slides() {

	document.getElementById("slide").src = imgs[k];
	
	k++;
	if (k > 5)
		k = 0
}

setInterval(slides, 3000)
