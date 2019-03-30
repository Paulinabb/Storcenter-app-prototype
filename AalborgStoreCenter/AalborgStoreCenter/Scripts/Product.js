GetProducts();
//GetProdCategoryId();
//function GetCategories() {




//    $.ajax({
//        type: "GET",
//        url: "http://localhost:63715/api/Categorie/GetCategories",
//        dataType: "json",
//        traditional: true,
//        cache: false,
//        complete: function (data) {
//            //JSON.stringify(data.responseText);
//            JSON.parse(data.ResponseText);
//            var ul = $('<ul>').appendTo('body');
//            $(data).each(function (index, val) {
//                ul.append('<li>' + val.CategoryName + '</li>');
//            });
//        }
//    });
//}




function GetProducts() {

    //if (currentCategoryId != 0) {
    
        var catId = currentCategoryId;

        $.ajax({
            type: "GET",
            url: "http://localhost:63715/api/Product/GetProduct",
            dataType: "json",
            data: { id: catId },
            traditional: true,
            complete: function (data) {
                //JSON.parse(data.ResponseText);
                //                var ul = $('<ul>').appendTo('body');
                //                $(data).each(function (index, val) {
                //                    ul.append('<li>' + val.ProductTitle + '</li>');
                //                });
                //JsonDisplay(data.responseText);
                console.log("CurrId:" + currentCategoryId);
            }
        });
    }



//function JsonDisplay(response) {
//    var prodObj = JSON.parse(response);

//    // define the array
//    var productList = [];

//    // assign values to array
//    for (var k in prodObj) {
//        productList.push(prodObj[k].ProductTitle + " " + prodObj[k].ProductDescription);
//    }


//    // get the container
//    var container = document.getElementById("ProdDivId");

//    // calculate the length of array
//    var listLength = Object.keys(productList).length;


//    if (listLength > 0) {

//        // Create the Unordered list if there are elements present in the array
//        var myList = document.createElement("ul");

//        // add a class name to list
//        myList.className = "list";

//        // iterate through the array
//        for (var i = 0; i < listLength; i++) {

//            // create list item for every element
//            var listItem = document.createElement("li");

//            // create a text node to store value
//            var listValue = document.createTextNode(productList[i]);

//            // append the value in the list item
//            listItem.appendChild(listValue);

//            // append the list item in the list
//            myList.appendChild(listItem);
//        }

//        // append the list in the container
//        container.appendChild(myList);

//    } else {

//        // Create a text node with the message
//        var message = document.createTextNode("Empty list ...");

//        // Append the message to the container
//        container.appendChild(message);
//    }
//}

//function GetProdCategoryId()
//{
//    var elements = document.querySelectorAll("button");
//    for (var i = 0; i < elements.length; i++)
//    {
//        elements[i].addEventListener("click", function ()
//        {
//            console.log(this.id)
//        }, true);
//    }
//}