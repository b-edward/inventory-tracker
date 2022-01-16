
function validateEditProduct() {
    var isValid = 0;
    var errorMessage = "REQUIRED:"

    // Clear error messages
    document.getElementById("errorMessage").innerHTML = "";

    // Validate that the id is an integer          
    var productID = document.getElementById("txtProductID").value;
    var numbers = /^[0-9\s]+$/;          // Regex used to filter for valid integers
    if (productID.match(numbers) && productID > 0) {
        isValid = 1;
    }
    else {
        errorMessage += " product ID";
        isValid = 0;
    }

    // Validate name is alpha-only
    var productName = document.getElementById("txtProductName").value;
    var lettersNSpaces = /^[A-Za-z\s]+$/;           // Regex used to filter for valid alpha chars
    if (productName.match(lettersNSpaces)) {
        isValid = 1;
    }
    else {
        errorMessage += " product name";
        isValid = 0
    }

    var returnBool;
    if (isValid == 0) {
        returnBool = false;
        document.getElementById("errorMessage").innerHTML = errorMessage;
    }
    else {
        returnBool = true;
    }

    return returnBool;
}


function validateAddProduct() {
    var isValid = false;
    // Clear error messages
    document.getElementById("errorMessage").innerHTML = "";

    // Validate name is alpha-only
    var productName = document.getElementById("txtProductName").value;
    var lettersNSpaces = /^[A-Za-z\s]+$/;           // Regex used to filter for valid alpha chars
    if (productName.match(lettersNSpaces)) {
        isValid = true;
    }
    else {
        document.getElementById("errorMessage").innerHTML += "REQUIRED: product name";
        isValid = false
    }
    return isValid;
}