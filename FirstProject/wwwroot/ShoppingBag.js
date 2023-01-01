
window.addEventListener("load", GetCart());

function GetCart() {
   
    var cart = sessionStorage.getItem("cart");


    if (cart) {
        cart = JSON.parse(cart);
        console.log(cart);
        for (let i = 0; i < cart.length; i++) {
            drawProductInCart(cart[i]);
        }
        /*cart.forEach(product => drawProductInCart(product))*/
    }
    else {
        alert("הסל ריק");
    }


}

function drawProductInCart(product) {
    var totalPrice = sessionStorage.getItem("totalPrice");
    totalPricet = JSON.parse(totalPrice);
    var tprice = String(totalPricet);
    console.log(tprice);
    document.getElementById("totalAmount").innerText = tprice;

    var tmp = document.getElementById("temp-row");
    var clon = tmp.content.cloneNode(true);
    clon.querySelector(".itemName").innerText = product.name;
    clon.querySelector(".image").style.backgroundImage =`url(${"./NewFolder/" + product.imgUrl})` ;
    document.body.appendChild(clon);
}


  //<td class="imageColumn"><a rel="lightbox" href="#"><div class="image"></div></a></td>
  //          <td class="descriptionColumn"><div