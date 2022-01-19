/*
 * FILE             : InputValidation.js
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains JavaScript code which is responsible for input-level validation.
 */

const regexNumbers = /^[0-9]+$/;                    // Regex used to filter for valid integers
const regexLetters = /^[A-Za-z ]+$/;                // Regex used to filter for valid alpha chars
const regexLettersNumbers = /^[a-zA-Z0-9 ]*$/;      // Regex used to filter for valid alpha and integer chars

/*
*	NAME	:	validateAddProduct
*	PURPOSE	:	This method will validate non-id fields by calling the validateProduct function
*	INPUTS	:	None
*	RETURNS	:	bool isValid - true if the user input is valid
*/

function validateAddProduct() {
    // Validate non-id fields only
    var isValid = validateProduct();
    return isValid;
}

/*
*	NAME	:	validateEditProduct
*	PURPOSE	:	This method will validate non-id fields by calling the validateProduct function, then
*               validate the id as well.
*	INPUTS	:	None
*	RETURNS	:	bool isValid - true if the user input is valid
*/

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

/*
*	NAME	:	validateProduct
*	PURPOSE	:	This method will validate non-id fields for product editing/creating
*	INPUTS	:	None
*	RETURNS	:	bool isValid - true if the user input is valid
*/

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

/*
*	NAME	:	validateAddItem
*	PURPOSE	:	This method will validate non-id fields by calling the validateItem function
*	INPUTS	:	None
*	RETURNS	:	bool isValid - true if the user input is valid
*/

function validateAddItem() {
    // Validate non-id fields only
    var isValid = validateItem();
    return isValid;
}

/*
*	NAME	:	validateEditItem
*	PURPOSE	:	This method will validate non-id fields by calling the validateItem function, then
*               validate the id as well.
*	INPUTS	:	None
*	RETURNS	:	bool isValid - true if the user input is valid
*/

function validateEditItem() {
    // Validate non-id fields
    var isValid = validateItem();

    // Validate the item id
    var itemID = document.getElementById("txtItemId").value;
    var errorMessage = document.getElementById("errorMessage").innerHTML;
    if (!itemID.match(regexNumbers) || itemID < 1) {
        if (errorMessage.length > 0) {
            errorMessage += ", item ID";
        } else {
            errorMessage = "Invalid: item ID";
        }
        document.getElementById("errorMessage").innerHTML = errorMessage;
        isValid = false;
    }
    return isValid;
}

/*
*	NAME	:	validateItem
*	PURPOSE	:	This method will validate non-id fields for creating/updating an item record
*	INPUTS	:	None
*	RETURNS	:	bool isValid - true if the user input is valid
*/

function validateItem() {
    var isValid = true;
    var errorMessage = "Invalid:"

    // Clear error messages
    document.getElementById("errorMessage").innerHTML = "";

    // Validate the product id
    var productID = document.getElementById("txtProductIDItems").value;
    if (!productID.match(regexNumbers) || productID < 1) {
        errorMessage += " product ID,";
        isValid = false;
    }

    // Validate the warehouse id
    var warehouseID = document.getElementById("txtWarehouseIDItems").value;
    if (!warehouseID.match(regexNumbers) || warehouseID < 0) {
        errorMessage += " warehouse ID,";
        isValid = false;
    }

    // Validate availability
    var isSold = document.getElementById("ddlIsSold").value;
    if (!isSold.match(regexNumbers) || isSold > 1 || isSold < 0) {
        errorMessage += " availability,";
        isValid = false;
    }

    // Display error message if applicable
    if (isValid == false) {
        errorMessage = errorMessage.substring(0, errorMessage.length - 1);
        document.getElementById("errorMessage").innerHTML = errorMessage;
    }
    return isValid;
}

/*
*	NAME	:	validateAddWarehouse
*	PURPOSE	:	This method will validate non-id fields by calling the validateItem function
*	INPUTS	:	None
*	RETURNS	:	bool isValid - true if the user input is valid
*/

function validateAddWarehouse() {
    // Validate non-id fields
    var isValid = validateWarehouse();
    return isValid;
}

/*
*	NAME	:	validateEditWarehouse
*	PURPOSE	:	This method will validate non-id fields by calling the validateItem function, then
*               then also validate the id
*	INPUTS	:	None
*	RETURNS	:	bool isValid - true if the user input is valid
*/

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

/*
*	NAME	:	validateWarehouse
*	PURPOSE	:	This method will validate non-id fields for creating/updating a warehouse record
*	INPUTS	:	None
*	RETURNS	:	bool isValid - true if the user input is valid
*/

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