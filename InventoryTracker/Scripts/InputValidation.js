
function validateAddProduct() {
    var isValid;
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


function validateEditProduct() {
    var isValid;
    var errorMessage = "REQUIRED:"

    // Clear error messages
    document.getElementById("errorMessage").innerHTML = "";

    // Validate that the id is an integer          
    var productID = document.getElementById("txtProductID").value;
    var numbers = /^[0-9\s]+$/;          // Regex used to filter for valid integers
    if (productID.match(numbers) && productID > 0) {
        isValid = true;
    }
    else {
        errorMessage += " product ID";
        isValid = false;
    }

    // Validate name is alpha-only
    var productName = document.getElementById("txtProductName").value;
    var lettersNSpaces = /^[A-Za-z\s]+$/;           // Regex used to filter for valid alpha chars
    if (productName.match(lettersNSpaces)) {
        isValid = true;
    }
    else {
        errorMessage += " product name";
        isValid = false;
    }

    if (isValid == false) {
        document.getElementById("errorMessage").innerHTML = errorMessage;
    }

    return isValid;
}



function validateAddItem() {
    var isValid;

    isValid = true;

    return isValid;
}

function validateEditItem() {
    var isValid;

    isValid = true;

    return isValid;
}


function validateAddWarehouse() {
    var isValid;

    isValid = true;

    return isValid;
}

function validateEditWarehouse() {
    var isValid;

    isValid = true;

    return isValid;
}