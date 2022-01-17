
const regexNumbers = /^[0-9]+$/;                    // Regex used to filter for valid integers
const regexLetters = /^[A-Za-z ]+$/;                // Regex used to filter for valid alpha chars
const regexLettersNumbers = /^[a-zA-Z0-9 ]*$/;      // Regex used to filter for valid alpha and integer chars


function validateAddProduct() {
    // Validate non-id fields
    var isValid = validateProduct();
    return isValid;
}

function validateEditProduct() {
    // Validate non-id fields
    var isValid = validateProduct();

    // Validate the id         
    var productID = document.getElementById("txtProductID").value;
    var errorMessage = document.getElementById("errorMessage").innerHTML;
    if (!productID.match(regexNumbers) || productID < 1) {
        if (errorMessage.length > 0) {
            errorMessage += ", product ID";
        } else {
            errorMessage = "Invalid: product ID";
        }
        document.getElementById("errorMessage").innerHTML = errorMessage;
        isValid = false;
    }

    return isValid;
}

function validateProduct() {
    var isValid = true;
    var errorMessage = "Invalid:"

    // Clear error messages
    document.getElementById("errorMessage").innerHTML = "";

    // Validate name is alpha-only
    var productName = document.getElementById("txtProductName").value;
    if (!productName.match(regexLetters) || productName.length < 1) {
        errorMessage += " product name,";
        isValid = false;
    }

    // Display error message if applicable
    if (isValid == false) {
        errorMessage = errorMessage.substring(0, errorMessage.length - 1);
        document.getElementById("errorMessage").innerHTML = errorMessage;
    }
    return isValid;
}


function validateAddItem() {
    var isValid = true;


    return isValid;
}

function validateEditItem() {
    var isValid = true;


    return isValid;
}

function validateItem() {
}


function validateAddWarehouse() {
    // Validate non-id fields 
    var isValid = validateWarehouse();
    return isValid;
}

function validateEditWarehouse() {
    // Validate non-id fields
    var isValid = validateWarehouse();

    // Validate the id         
    var warehouseID = document.getElementById("txtWarehouseID").value;
    var errorMessage = document.getElementById("errorMessage").innerHTML;
    if (!warehouseID.match(regexNumbers) || warehouseID < 1) {
        if (errorMessage.length > 0) {
            errorMessage += ", warehouse ID";
        } else {
            errorMessage = "Invalid: warehouse ID";
        }
        document.getElementById("errorMessage").innerHTML = errorMessage;
        isValid = false;
    }

    return isValid;
}

function validateWarehouse() {
    var isValid = true;
    var errorMessage = "Invalid:"

    // Clear error messages
    document.getElementById("errorMessage").innerHTML = "";

    // Validate street and number
    var streetAndNo = document.getElementById("txtStreetAndNo").value;
    if (!streetAndNo.match(regexLettersNumbers) || streetAndNo.length < 1) {
        errorMessage += " street and number,";
        isValid = false;
    }

    // Validate city 
    var city = document.getElementById("txtCity").value;
    if (!city.match(regexLetters) || city.length < 1) {
        errorMessage += " city,";
        isValid = false;
    }

    // Validate province/state 
    var provinceOrState = document.getElementById("txtProvinceOrState").value;
    if (!provinceOrState.match(regexLetters) || provinceOrState.length < 1) {
        errorMessage += " province/state,";
        isValid = false;
    }

    // Validate country 
    var country = document.getElementById("txtCountry").value;
    if (!country.match(regexLetters) || country.length < 1) {
        errorMessage += " country,";
        isValid = false;
    }

    // Validate postal code 
    var postalCode = document.getElementById("txtPostalCode").value;
    if (!postalCode.match(regexLettersNumbers) || postalCode.length < 1) {
        errorMessage += " postal code,";
        isValid = false;
    }

    // Validate active status 
    var isActive = document.getElementById("ddlWarehouseActive").value;
    if (!isActive.match(regexNumbers) || isActive > 1 || isActive < 0) {
        errorMessage += " status,";
        isValid = false;
    }

    // Display error message if applicable
    if (isValid == false) {
        errorMessage = errorMessage.substring(0, errorMessage.length - 1);
        document.getElementById("errorMessage").innerHTML = errorMessage;
    }

    return isValid;
}