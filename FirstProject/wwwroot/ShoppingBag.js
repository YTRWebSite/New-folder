
window.addEventListener("load", GetCart());
var cart;
function GetCart() {
   
     cart = sessionStorage.getItem("cart");


    if (cart) {
        cart = JSON.parse(cart);
        console.log(cart);
        for (let i = 0; i < cart.length; i++) {
            drawProductInCart(cart[i],i);
        }
        /*cart.forEach(product => drawProductInCart(product))*/
    }
    else {
        alert("הסל ריק");
    }


}

function drawProductInCart(product,i) {
    var totalPrice = sessionStorage.getItem("totalPrice");
    totalPricet = JSON.parse(totalPrice);
    var tprice = String(totalPricet);
    console.log(tprice);
    document.getElementById("totalAmount").innerText = tprice;

    var tmp = document.getElementById("temp-row");
    var clon = tmp.content.cloneNode(true);
    clon.querySelector(".itemName").innerText = product.name;
    clon.querySelector(".showText").addEventListener("click", () => removeToCart(i));

    clon.querySelector(".image").style.backgroundImage =`url(${"./NewFolder/" + product.imgUrl})` ;
    document.body.appendChild(clon);
}
function removeToCart(i) {

    cart.splice(i, 1);
    sessionStorage.setItem("cart", JSON.stringify(cart));
   removeProductsInCart();
    GetCart();


}

function removeProductsInCart() {
    var cards = document.getElementsByClassName("item-row");
    for (var i = cards.length; i > 0; i--) {
        cards[0].remove();
    }
}
async function placeOrder() {
    let userobject = sessionStorage.getItem('details')
    const tmp = JSON.parse(userobject);
    const id = tmp["id"];
  
    
    const order = {
        "Id":0,
        "OrderDate": new Date(),
        "OrderSum": sessionStorage.getItem("totalPrice"),
        "OrderUserid": id,
        "OrderUser": 0,
        "OrderItems":[]
    }
    for (let i; i < cart.length; i++) {
        OrderItem = {
            "Id": 0,
            "OrderId":0,
            "ProductId": cart[i].id,
            "Amount": 1
        }
        order.orderItems.push(OrderItem);
        console.log(order.orderItems[0].Amount)
    }
    const Order = await fetch(`https://localhost:44387/api/Order`, {
    headers: { "Content-Type": "application/json; charset=utf-8" },
    method: 'POST',
        body: JSON.stringify(order)
    })
    const res = Order.json();
    alert("הזמנתך נקלטה במערכת ,תודה על קניתך נשמח לראותך שוב!")
}
