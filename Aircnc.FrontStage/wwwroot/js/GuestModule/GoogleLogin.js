

function onSignIn(googleUser) {
    let profile = googleUser.getBasicProfile();
    //const id_token = googleUser.getAuthResponse().id_token;
    //console.log('token:' + id_token);
    //console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
    //console.log('Name: ' + profile.getName());
    //console.log('Image URL: ' + profile.getImageUrl());
    //console.log('Email: ' + profile.getEmail()); // This is null if the 'email' scope is not present.

    let data = {
        Name: profile.getName(),
        Email: profile.getEmail(),
        Password: profile.getId() + '_' + profile.getEmail(),
        TypeOfLogin : 2
    };
    ThirdLogin(data);
    googleUser.disconnect();

}

function onFailure(error) {
    console.log(error);
}

//渲染出登入btn
function renderButton() {
    gapi.signin2.render('btn_GoogleLogin', {
        'scope': 'profile email',
        'width': 450,
        'height': 50,
        'longtitle': true,
        'theme': 'dark',
        'onsuccess': onSignIn,
        'onfailure': onFailure
    });
}
function renderButton2() {
    gapi.signin2.render('btn_GoogleLogin2', {
        'scope': 'profile email',
        'width': 450,
        'height': 50,
        'longtitle': true,
        'theme': 'dark',
        'onsuccess': onSignIn,
        'onfailure': onFailure
    });
}

function signOut() {
    let auth2 = gapi.auth2.getAuthInstance();
    auth2.signOut().then(function () {
        console.error('User signed out.');
    });
}

function ThirdLogin(data) {
    console.log(data);
    //Name, Email, Password
    //let data = {
    //    Name:,
    //    Email: ,
    //    Password: ,
    //}
    fetch('/Account/ThirdLogin', {
        headers: {
            'Accept': 'application/json, text/plain',
            'Content-Type': 'application/json;charset=UTF-8'
        },
        method: 'POST',
        body: JSON.stringify(data)
    })
        .then(response => response.json())
        .then(jsonData => {
            console.log(jsonData)
            if (jsonData.isSuccess) {
                //關閉Modal
                $('#LoginModal').modal('hide')

                window.location.reload()
            }
            else {
                loginMessageShow.innerHTML = `<span class='message-show text-danger'>${jsonData.message}</span>`
            }
        });
}

