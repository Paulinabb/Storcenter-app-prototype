GetAllCategories();

var currButtonId = 0;
var productListByCategory = [];

//function Modal() {
//    // Get the modal
//    var modal = document.getElementById('myModal');

//    // Get the button that opens the modal
//    var btn = document.getElementById(currButtonId);

//    // Get the <span> element that closes the modal
//    var span = document.getElementsByClassName("close")[0];

//    // When the user clicks on the button, open the modal 
//    btn.onclick = function () {
//        modal.style.display = "block";
 //     GetProductsByCategory();
//    }

//    // When the user clicks on <span> (x), close the modal
//    span.onclick = function () {
//        modal.style.display = "none";
//    }

//    // When the user clicks anywhere outside of the modal, close it
//    window.onclick = function (event) {
//        if (event.target == modal) {
//            modal.style.display = "none";
//        }
//    }
//}

function GetAllCategories() {
    $.ajax({
        type: "GET",
        url: "http://localhost:63715/api/Categorie/GetCategories",
        dataType: "json",
        traditional: true,
        complete: function (data) {
            console.log(data.responseText);
            JsonDisplayAllCategories(data.responseText);
        }
    });
} // Returns all categories

function GetProductsByCategory() {

    var catId = currButtonId;

    $.ajax({
        type: "GET",
        url: "http://localhost:63715/api/Product/GetProduct",
        dataType: "json",
        data: { id: catId },
        traditional: true,
        complete: function (data) {
            document.getElementById("CatDiv").innerHTML = "";
            JsonDisplayProduct(data.responseText);
        }
    });
} // Returns all products belonging to the specific category

function GetProductById() {
    $.ajax({
        type: "GET",
        url: "http://localhost:63715/api/Product/GetProductById",
        dataType: "json",
        data: { id: currButtonId },
        traditional: true,
        complete: function (data) {
            JsonDisplayProductDetails(data.responseText);
        }
    });
} // Returns specific product by its ID

function AddProductToList(prodId)
{
    $.ajax({
        type: "POST",
        url: "http://localhost:63715/api/SelectedProduct/PostSelectedProduct/" + prodId,
        content: "application/json",
        dataType: "json",
        data: { id: prodId },
        traditional: true,
        complete: function (data) {
            window.location.href = "../Frontend/Main.html";
        }
    });
}

function JsonDisplayAllCategories(response) {
    var prodObj = JSON.parse(response);
    var categoryList = [];

    for (var k in prodObj) {
        categoryList.push(prodObj[k].CategoryName);
    }

    var container = document.getElementById("CatDiv");
    var listLength = Object.keys(categoryList).length;

    if (listLength > 0) {

        // Create the Unordered list if there are elements present in the array
        var catUl = document.createElement("ul");

        // add a class name to list
        catUl.className = "list";

        // iterate through the array
        for (var i = 0; i < listLength; i++) {

            // create list item for every element
            var catLi = document.createElement("li");
            var catBtn = document.createElement("button");
            catBtn.setAttribute("Id", prodObj[i].CategoryID);
            catBtn.setAttribute("data-catId", prodObj[i].CategoryID);
            catBtn.onclick = function () {
                currButtonId = $(this).data('catid');
                GetProductsByCategory();
               // Modal();
            };

            // create a text node to store value
            var listValue = document.createTextNode(categoryList[i]);

            // append the list item in the list
            catUl.appendChild(catLi);

            catLi.appendChild(catBtn);

            // append the value in the list item
            catBtn.appendChild(listValue);

           
        }

        // append the list in the container
        container.appendChild(catUl);

    } else {

        // Create a text node with the message
        var message = document.createTextNode("Empty list ...");

        // Append the message to the container
        container.appendChild(message);
    }
} // Displays the content of GetAllCategories

function JsonDisplayProduct(response) {


    var prodObj = JSON.parse(response);

    // define the array
    

    // assign values to array
    // Check if the array was already created
    if (Object.keys(productListByCategory).length == 0) {
        for (var k in prodObj) {
            productListByCategory.push(prodObj[k].ProductTitle);
        }

    // get the container
        var container = document.getElementById("ProdContId");

    // calculate the length of array
    var listLength = Object.keys(productListByCategory).length;

    if (listLength > 0) {
        // Create the Unordered list if there are elements present in the array
        var myList = document.createElement("div");
        myList.setAttribute("id", "DispProdDivId")

        // add a class name to list
        myList.className = "list";

        // iterate through the array
        for (var i = 0; i < listLength; i++) {

            // create list item for every element
            var listItem = document.createElement("button");
            listItem.setAttribute("Id", prodObj[i].ProductID);
            listItem.setAttribute("data-prodid", prodObj[i].ProductID);

            listItem.onclick = function () {
                currButtonId = $(this).data('prodid');
                GetProductById();
                $("#DispProdDivId").empty();
            };

            // create a text node to store value
            var listValue = document.createTextNode(productListByCategory[i]);

            // append the value in the list item
            listItem.appendChild(listValue);

            // append the list item in the list
            myList.appendChild(listItem);
        }

        // append the list in the container
        container.appendChild(myList);
    }

    } else {

        // Create a text node with the message
        //var message = document.createTextNode("Empty list ...");

        // Append the message to the container
        //container.appendChild(message);
    }
}

function JsonDisplayProductDetails(response)
{
    var prodObj = JSON.parse(response);

    var title = document.getElementById("ProductTitle");
    var productDescription = document.getElementById("ProductDescription");
    var productImage = document.getElementById("ProductImage");
    var addToListId = document.getElementById("addToListId");

    var productPrice = document.getElementById("ProductPrice");
    var productPriceValue = document.createTextNode("Price:" + prodObj.ProductPrice + "DKK");

    var addToListBtn = document.createElement("button");
    var btnValue = document.createTextNode("Add to list");

    var productImg = document.createElement("img");
    productImg.setAttribute("src", "../Images/" + prodObj.ProductImage);
    productImg.setAttribute("id", "productImage");

    $(title).append(prodObj.ProductTitle);
    $(productDescription).append(prodObj.ProductDescription);

    productImage.appendChild(productImg);

    productPrice.appendChild(productPriceValue);

    addToListBtn.appendChild(btnValue);
    addToListId.appendChild(addToListBtn);

    addToListBtn.onclick = function () {

        AddProductToList(prodObj.ProductID);
    };
}

function InsideModalVisibilityNone() {
    var modalContent = document.getElementById("DispProdDivId");

    if(modalContent.style.display === "block")
    {
        modalContent.style.display = "none";
    }
} // Set the visibility in the Modal Content Div to None

function InsideModalVisibilityBlock()
{
    var modalContent = document.getElementById("DispProdDivId");

    if (modalContent.style.display === "none") {
        modalContent.style.display = "block";
    }
} // Set the visibility in the Modal Content Div to block