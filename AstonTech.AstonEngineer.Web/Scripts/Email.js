function ValidateClientForm() {
    var textBoxArray = document.getElementsByClassName("EmailAddressField");
    var dropDownArray = document.getElementsByClassName("EmailTypeField");
    var emailAddressField;
    var emailTypeField;

    if (textBoxArray.length >= 1) {
        emailAddressField = textBoxArray.item(0);

        if (emailAddressField.value.trim().length <= 0) {
            alert("Email Address field is  required.");
            emailAddressField.focus();

            return false;
        }
    }

    if (dropDownArray.length >= 1) {
        emailTypeField = dropDownArray.item(0);

        if (emailTypeField.value <= 0) {
            alert("Email Type is required. Please select a valid item from the drop-down.");
            emailTypeField.focus();

            return false;
        }
    }
}