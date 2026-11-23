const email = document.querySelector("#email")
const psswrd = document.querySelector("#password")
const firstN = document.querySelector("#First_Name")
const lastN = document.querySelector("#Last_Name")
const registerButton = document.querySelector("#registerButton")
const passwordStrength = document.getElementById("passwordStrength")
const emailLog = document.querySelector("#emailLogin")
const psswrdLog = document.querySelector("#passwordLogin")
const loginButton = document.querySelector("#loginButton")
const progressPassword = document.querySelector("progress")

registerButton.addEventListener('click', async (e) => {
    try { 
        if ( psswrd.value.length < 4 || firstN.value.length < 2 || lastN.value.length < 2) 
            throw Error("Unvalid details!")
        }
    catch (Error) {
        alert(Error + "  Please enter again your details! Pay attention the explanation")
        return;
        }
    
        const postData = {
            email: email.value,
            password: psswrd.value,
            First_Name: firstN.value,
            Last_Name: lastN.value,
           
        
    };
    const response = await fetch('/api/User/register',
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'},
            body: JSON.stringify(postData)
        });
    try {
        if (!response.ok) {
            const errorDetails = await response.text();
            throw new Error('Error: ' + response.status + ' ' + errorDetails);
        }
    }
    catch (err) {
        alert(err.message + " Please enter again your details!");
        return;
    }


    const dataPost = await response.json()
    console.log('POST data:', dataPost)
    alert('User registered successfully!')

})


passwordStrength.addEventListener('click',async (e) => {

  
    const postData = {
        password: psswrd.value,
        // title: 'Check passwords strength',
        // body: 'This is a sub validation action'

    };
    const response = await fetch('/api/User/passwordStrength',
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(postData)
        });
 
      
    let score =0;
    const dataPost = await response.json()
    if (!response.ok) {
        score = dataPost.score;
       const message = dataPost.message;
        const suggestions = dataPost.suggestions;
        const warning = dataPost.warning;
        alert("message:" + massage + "suggestions: " + suggestions + "warning: "+warning)
    }
    else {
        score = dataPost.score;
        const message = dataPost.massage;
       alert("message:" + massage )
    }

    progressPassword.value = score;

})



loginButton.addEventListener('click', async (e) => {
    try {
        if (psswrdLog.value.length < 4 )
            throw Error("Unvalid details!")
    }
    catch (Error) {
        alert(Error + "  Please enter again your details! Pay attention the explanation")
        return;
    }

    const postData = {
        email: emailLog.value,
        password: psswrdLog.value,
        // title: 'login, user details',
        // body: 'This is a login action'

    };
    const response = await fetch('/api/User/login',
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(postData)
        });
    try {
        if (!response.ok) {
            const errorDetails = await response.text();
            throw new Error('Error: ' + response.status + ' ' + errorDetails);
        }
    }
    catch (err) {
        alert(err.message + " Please enter again your details!");
        return;
    }
   
    const dataPost = await response.json()
    localStorage.setItem('dataPost', JSON.stringify(dataPost))
    console.log('POST data:', dataPost)
    alert('User login successfully!')
    window.location.href = '/UpdateUser/update.html'


})
