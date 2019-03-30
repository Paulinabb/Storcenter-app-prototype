GetCategory();

var currentCategoryId = 0;

function GetCategory()
{
    $.ajax({
        type: "GET",
        url: "http://localhost:63715/api/Categorie/GetCategories",
        dataType: "json",
       // data: { id: prodId },
        traditional: true,
        complete: function (data) {
            console.log(data.responseText);
            JsonDisplayCategory(data.responseText);
        }
    });
}

function JsonDisplayCategory(response) {
    var prodObj = JSON.parse(response);

    // define the array
    var productList = [];

    // assign values to array
    for (var k in prodObj) {
        productList.push(prodObj[k].CategoryName);
    }


    // get the container
    var container = document.getElementById("CatDiv");

    // calculate the length of array
    var listLength = Object.keys(productList).length;


    if (listLength > 0) {

        // Create the Unordered list if there are elements present in the array
        var myList = document.createElement("div");

        // add a class name to list
        myList.className = "list";

        // iterate through the array
        for (var i = 0; i < listLength; i++) {

            // create list item for every element
            var button = document.createElement("button");
            button.setAttribute("Id", prodObj[i].CategoryID);
            button.onclick = function () {
                GetProdCategoryId();
               // window.location.href = "../Frontend/Product.html";
            };

            // create a text node to store value
            var listValue = document.createTextNode(productList[i]);

            // append the value in the list item
            button.appendChild(listValue);

            // append the list item in the list
            myList.appendChild(button);
        }

        // append the list in the container
        container.appendChild(myList);

    } else {

        // Create a text node with the message
        var message = document.createTextNode("Empty list ...");

        // Append the message to the container
        container.appendChild(message);
    }
}

function GetProdCategoryId() {
    var elements = document.querySelectorAll("button");
    for (var i = 0; i < elements.length; i++) {
        elements[i].addEventListener("click", function () {
            console.log(this.id);
            currentCategoryId = this.id;
            window.location.href = "../Frontend/Product.html";
        }, true);
    }
}
