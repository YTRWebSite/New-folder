update = () => {
    valuOfInput();
    let userobject = sessionStorage.getItem('details')
    const tmp = JSON.parse(userobject);
    const real = tmp["firstName"];
    document.getElementById("hello").innerHTML = `hello ${real}!!!!!!!!!`;
    document.getElementById("details").style.display = "block"
}
get = () => {
   
}
async function ok() {
    let userobject = sessionStorage.getItem('details')
    const tmp = JSON.parse(userobject);
    const id = tmp["id"];
    alert(id)
    //let userobject = sessionStorage.getItem('details')
    //const tmp = JSON.parse(userobject);
    ////const real = tmp["firstName"];
    ////document.getElementById("firsrName").innerHTML = `hello ${real}!!!!!!!!!`;
    const updatuser = {
        
     "User1": document.getElementById("user").value,
     "id": id,
     "password": document.getElementById("password").value,
     "email" : document.getElementById("email").value,
     "phone" : document.getElementById("phone").value,
     "firstName": document.getElementById("firstName").value,
     "lastName":document.getElementById("lastName").value}

    const res = await fetch(`https://localhost:44387/api/user/${id}`, {
        headers: { "Content-Type": "application/json; charset=utf-8" },
        method: 'PUT',
        body: JSON.stringify(updatuser)
    });
    
    if (res.ok) {
        const r = await res.json()
        sessionStorage.setItem('details', JSON.stringify(r))
        let userobject = sessionStorage.getItem('details')
        const tmp = JSON.parse(userobject);
        const firstName = tmp["firstName"];
        alert(firstName);
     
    }

}
valuOfInput = () =>
{
    let userobject = sessionStorage.getItem('details')
    const tmp = JSON.parse(userobject);
    const firstname = tmp["firstName"];
    let fn = document.getElementById("firstName");
    fn.setAttribute("value", firstname);
    const lastname = tmp["lastName"];
    let ln = document.getElementById("lastName");
    ln.setAttribute("value", lastname);
    const email = tmp["email"];
    let email1 = document.getElementById("email");
    email1.setAttribute("value", email);
    const phone = tmp["phone"];
    let phone1 = document.getElementById("phone");
    phone1.setAttribute("value", phone);
    const user = tmp["user1"];
    let User1 = document.getElementById("user");
    User1.setAttribute("value", user);
    const password = tmp["password"];
    let password1 = document.getElementById("password");
    password1.setAttribute("value", password);

}
 
