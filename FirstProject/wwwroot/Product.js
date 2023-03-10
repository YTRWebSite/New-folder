
window.addEventListener("load", async (event) => {
   let product = sessionStorage.getItem('cart')
    const tmp = JSON.parse(product);
    if (tmp != null) {
        document.getElementById("ItemsCountText").innerText = tmp.length;
    }
    GetProduct();
    GetCategory();
})


async function GetProduct() {

    const res = await fetch(`https://localhost:44387/api/Product/get`)
    const data = await res.json();
    sessionStorage.setItem("products", JSON.stringify(data));
    drawProducts(data);
}
function drawProducts(products) {
    products.forEach(product => drawProduct(product))
}

function drawProduct(product) {
    var price = String(product.price)
    var tmp = document.getElementById("temp-card");
    var clon = tmp.content.cloneNode(true);
    clon.querySelector("h1").innerText = product.name;
    //clon.querySelector(".cat").innerText = product.CategoryName;
    clon.querySelector(".price").innerText = price;
    clon.querySelector("button").addEventListener("click", () => addToCart(product));
    clon.querySelector(".description").innerText = product.descreption;
    clon.querySelector("img").src = "./NewFolder/" + product.imgUrl;

    document.body.appendChild(clon);    
}
 tempcart = [];
 cart =[];
var totalPrice = 0;
console.log(totalPrice);
function addToCart(product) {
    tempcart = sessionStorage.getItem('cart');
    var temp = JSON.parse(tempcart);
    if (temp != null) {
        cart = temp;
    }
    cart.push(product);
    totalPrice = totalPrice + product.price;
    sessionStorage.setItem("cart", JSON.stringify(cart));
    sessionStorage.setItem("totalPrice", JSON.stringify(totalPrice));
    document.getElementById("ItemsCountText").innerText = cart.length;
    clon.querySelector("button").addEventListener("click", () => addToCart(product));
}


async function GetCategory() {
    const res = await fetch(`https://localhost:44387/api/Category`)
    const data = await res.json();
    drawCategories(data);

}
function drawCategories(Categories) {
    Categories.forEach(Category => drawCategory(Category))
}
drawCategory = (Category) => {

    var tmp = document.getElementById("temp-category");
    var clon = tmp.content.cloneNode(true);
    clon.querySelector(".opt").id = Category.name;
    clon.querySelector(".opt").value = Category.id;
    clon.querySelector(".OptionName").innerText = Category.name;
    document.getElementById("categoryList").appendChild(clon);
}
 async function filterProducts() {
    var name = document.getElementById("nameSearch").value;
    var minPrice = document.getElementById("minPrice").value;
    var maxPrice = document.getElementById("maxPrice").value;
     var categoryList = document.getElementsByClassName("opt");
   
    var start = 1;
    var limit = 20;
    var direction = "ASC";
    var orderBy = "price";
    var CategoryIds = "";
    for (let i = 0; i < categoryList.length; i++) {
        if (categoryList[i].checked) {
            CategoryIds += `&categoryIds=${categoryList[i].value}`;
        } 
    }
    const res = await fetch(`https://localhost:44387/api/Product/get?name=${name}&price_from=${minPrice}&price_to=${maxPrice}${CategoryIds}&start=${start}&limit=${limit}&direction=${direction}&orderBy=${orderBy}`)
    const data = await res.json();
    removeProducts();
    drawProducts(data);
}
removeProducts = () => {
    var cards = document.getElementsByClassName("card");
    for (var i = cards.length; i > 0; i--) {
        cards[0].remove();
    }
}