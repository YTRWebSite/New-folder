async function login() {
    let firstName = document.getElementById("name").value;
    let password = document.getElementById("code").value;
    const res = await fetch(`https://localhost:44387/api/user/?firstName=${firstName}&password=${password}`)

    if (res.ok) {
        const r = await res.json()
        sessionStorage.setItem('details', JSON.stringify(r))
        let userobject = sessionStorage.getItem('details')
        const tmp = JSON.parse(userobject);
        const firstName =tmp["firstName"];
        alert(firstName);
        window.location.href = "hellow.html"

    }}

show = () => {
    document.getElementById("newUser").style.display = "block"
    
}
async function newUser()  {
    let User1 = document.getElementById("user").value;
    let password = document.getElementById("password").value;
    let firstName = document.getElementById("firstName").value;
    let lastName = document.getElementById("lastName").value;
    let phone = document.getElementById("phone").value;
    let email = document.getElementById("email").value;
    User = { User1: User1, password: password, firstName: firstName, lastName: lastName, phone: phone, email: email }
    const res = await fetch("https://localhost:44387/api/Password", {
        headers: { "Content-Type": "application/json; charset=utf-8" },
        method: 'POST',
        body: JSON.stringify(User.password)
    })

    const data = await res.json();
    if (data>=2) {
        new1(User);
        alert(data);
    }
    else { alert("הסיסמא חלשה מדי") };

}

async function new1(User){ 
    const res = await fetch("https://localhost:44387/api/user", {
        headers: { "Content-Type": "application/json; charset=utf-8" },
        method: 'POST',
        body: JSON.stringify(User)
    })

    const data = res.json();
}