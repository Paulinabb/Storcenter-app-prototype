//CreateNewList();
GetExistingList();

function CreateNewList() {

    var getCreateNewListDiv = document.getElementById("createListId");

    var createPElement = document.createElement("p");
    createPElement.appendChild(document.createTextNode("Create new list..."));

    var createNewListBtn = document.createElement("button");
    createNewListBtn.appendChild(document.createTextNode("Create new list"));


    getCreateNewListDiv.appendChild(createPElement);
    getCreateNewListDiv.appendChild(createNewListBtn);

    $(createNewListBtn).click(function () {
        window.location.href = "../Frontend/Categories.html";
        //GetCategory();
    });
}

function GetExistingList() {
    $.ajax({
        type: "GET",
        url: "http://localhost:63715/api/List/GetUserList",
        dataType: "json",
        traditional: true,
        complete: function (data) {
            //DisplayList(data.responseText);
            CheckIfListEmpty(data.responseText);
        }
    });
} // Returns a list of users selected products

function DisplayList(response) {
    //var listObj = JSON.parse(response);

    var list = [];

    for (var i in response) {
        list.push(response[i]);
    }

    var displayListId = document.getElementById("displayListId");

    var ulEl = document.createElement("ul");

    for (var i in list) {
        var liEl = document.createElement("li");

        var prodNameDiv = document.createElement("div");
        prodNameDiv.setAttribute("id", "productNameDiv");

        var prodBtnDiv = document.createElement("div");
        prodBtnDiv.setAttribute("id", "productButtonDiv");

        var navigateBtn = document.createElement("button");
        navigateBtn.appendChild(document.createTextNode("Navigate"));

        var deleteBtn = document.createElement("button");
        deleteBtn.setAttribute("data-id", list[i].ProductID);
        deleteBtn.appendChild(document.createTextNode("X"));
        deleteBtn.style.cssText = "background-color: #be0000"
        deleteBtn.onclick = function () {
            DeleteProductFromList($(this).data('id'));
        };

        prodNameDiv.appendChild(document.createTextNode(list[i].ProductTitle));
        prodBtnDiv.appendChild(navigateBtn);
        prodBtnDiv.appendChild(deleteBtn);

        liEl.appendChild(prodNameDiv);
        liEl.appendChild(prodBtnDiv);

        ulEl.appendChild(liEl);
    }
    displayListId.appendChild(ulEl);
}

function DeleteProductFromList(id) {
    $.ajax({
        type: "DELETE",
        url: "http://localhost:63715/api/SelectedProduct/DeleteSelectedProductByProdId/" + id,
        dataType: "json",
        traditional: true,
        complete: function (data) {
            // $("#displayListId").empty();
            document.getElementById("displayListId").innerHTML = "";
            //CreateNewList();
            GetExistingList();
        }
    });
}

function CheckIfListEmpty(response) {
    var listObj = JSON.parse(response);

    var newList = [];
    if (listObj.length > 0) {
        for (var i in listObj) {
            newList.push(listObj[i]);
        }
        document.getElementById("displayListId").innerHTML = "";
        document.getElementById("addNewItemId").innerHTML = "";
        document.getElementById("emptyListId").innerHTML = "";
        DisplayList(listObj);

        var getAddNewItemDiv = document.getElementById("addNewItemId");

        var getEmptyListIdDiv = document.getElementById("emptyListId");

        var addNewItemBtn = document.createElement("button");
        addNewItemBtn.appendChild(document.createTextNode("Add new item to the list"));

        var emptyListIdBtn = document.createElement("button");
        emptyListIdBtn.appendChild(document.createTextNode("Delete my list"));

        emptyListIdBtn.onclick = function () {
            DeleteAllFromList();
        }

        getAddNewItemDiv.appendChild(addNewItemBtn);

        getEmptyListIdDiv.appendChild(emptyListIdBtn);

        $(addNewItemBtn).click(function () {
            window.location.href = "../Frontend/Categories.html";
            //GetCategory();
        });


    }
    else {
        document.getElementById("addNewItemId").innerHTML = "";
        document.getElementById("emptyListId").innerHTML = "";
        CreateNewList();
    }
}

function DeleteAllFromList() {
    $.ajax({
        type: "DELETE",
        url: "http://localhost:63715/api/SelectedProduct/DeleteAllSelectedProducts",
        dataType: "json",
        traditional: true,
        complete: function (data) {
            document.getElementById("displayListId").innerHTML = "";
            GetExistingList();
        }
    });
}