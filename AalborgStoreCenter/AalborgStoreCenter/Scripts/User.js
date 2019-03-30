/// <reference path="User.js" />
GetUserById();

function GetUserById() {

    var prodId = 1;

    $.ajax({
        type: "GET",
        url: "http://localhost:63715/api/user/getuser",
        dataType: "json",
        data: { id: prodId },
        traditional: true,
        complete: function (data) {
            console.log(data.responseText);
        }
    });
}


function ValidateUser()
{
    var uname = document.getElementById("uname").value;
    var psw = document.getElementById("psw").value;

    $.ajax({
        type: "GET",
        url: "http://localhost:63715/api/user/validateuser",
        dataType: "json",
        data: {username: uname, password: psw},
        traditional: true,
        success: function (data) {
                //alert('true');
                console.log(data.responseText);
                window.location.href = "../Frontend/Main.html";
          
        }
    });
}

function validateFormName() {
    var x = document.forms["formName"]["fname"].value;
    if (x == "") {
        alert("User name must be filled out");
        return false;
    }
    validateFormPassword();
}

function validateFormPassword() {
    var x = document.forms["formPassword"]["Pname"].value;
    if (x == "") {
        alert("Password must be filled out");
        return false;
    }
    ValidateUser();
}