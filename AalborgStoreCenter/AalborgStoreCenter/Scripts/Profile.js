GetUserProfile();

function GetUserProfile() {

    var userId = 1;

    $.ajax({
        type: "GET",
        url: "http://localhost:63715/api/user/getuser",
        dataType: "json",
        data: { id: userId },
        traditional: true,
        complete: function (data) {
            JsonDisplay(data.responseText);
        }
    });
}

function JsonDisplay(response) {

    var userObj = JSON.parse(response);

    var getUserNameDiv = document.getElementById("UserNameId");

    var getUserAdrressDiv = document.getElementById("UserAdrressId");

    var getUserBirthdateDiv = document.getElementById("UserBirthdateId");

    var addUserNameP = document.createElement("p");
    addUserNameP.appendChild(document.createTextNode("Your name:"));

    var addUserAdrressP = document.createElement("p");
    addUserAdrressP.appendChild(document.createTextNode("Addres:"));

    var addUserBirthdateP = document.createElement("p");
    addUserBirthdateP.appendChild(document.createTextNode("Birthdate:"));

    var displayUserNameP = document.createElement("p");
    displayUserNameP.appendChild(document.createTextNode(userObj.UserName));

    var displayUserAdrressP = document.createElement("p");
    displayUserAdrressP.appendChild(document.createTextNode(userObj.Address));

    var displayUserBirthdateP = document.createElement("p");
    displayUserBirthdateP.appendChild(document.createTextNode(userObj.Birthdate));

    var changeUserAdrressBtn = document.createElement("button");
    changeUserAdrressBtn.setAttribute("id", "changeBtn");
    changeUserAdrressBtn.appendChild(document.createTextNode("change address"));

    getUserNameDiv.appendChild(addUserNameP);
    addUserNameP.appendChild(displayUserNameP);

    getUserAdrressDiv.appendChild(addUserAdrressP);
    addUserAdrressP.appendChild(displayUserAdrressP);
    displayUserAdrressP.appendChild(changeUserAdrressBtn);

    getUserBirthdateDiv.appendChild(addUserBirthdateP);
    addUserBirthdateP.appendChild(displayUserBirthdateP);

    $(changeUserAdrressBtn).click(function () {
        document.getElementById("changeBtn").style.display = 'none';
        ChangeUserInfoForm();
    });
    //document.getElementById("UserDivId").innerHTML = "<p><b>Your name:</b></p>" + userObj.UserName + "<p><b>Addres:</b></p>" + userObj.Address + "<p><b>Birthdate:</b></p>" + userObj.Birthdate;
}

function ChangeUserInfoForm() {
    var getUserNameDiv = document.getElementById("UserChangeAddressId");

    var changeUserAddressLbl = document.createElement("label");
    changeUserAddressLbl.appendChild(document.createTextNode("New address:"));

    var changeUserAddressInpt = document.createElement("input");
    changeUserAddressInpt.setAttribute("placeholder", "Enter new address");
    changeUserAddressInpt.setAttribute("id", "adr");

    var changeUserAddressBtn = document.createElement("button");
    changeUserAddressBtn.appendChild(document.createTextNode("Change"));

    getUserNameDiv.appendChild(changeUserAddressLbl);
    changeUserAddressLbl.appendChild(changeUserAddressInpt);
    getUserNameDiv.appendChild(changeUserAddressBtn);

    $(changeUserAddressBtn).click(function () {
        ChangeUserInfo();
    });
}

function ChangeUserInfo() {

    var userid = 1;

    var adr = document.getElementById("adr").value;
    // var bdate = document.getElementById("bdate").value;
    /* var uname = document.getElementById("uname").value;
     
     var psw = document.getElementById("psw").value;
     */

    //var user = [{
    //    Birthdate: bdate,
    //    Address: adr,
    //}];

    $.ajax({
        type: "PUT",
        url: "http://localhost:63715/api/User/UpdateUser?address=" + adr,
        traditional: true,
        contentType: "application/x-www-form-urlencoded",
        complete: function (data) {
            console.log(data.responseText);
            window.location.href = "../Frontend/Profile.html";

        }
    });
}