$(document).ready(function (e) {
    //notes:    when page loads - set focus in the first name textbox
    $('.ValidateFirstName').focus();

    //notes:    attach event handler to save button
    $('.SaveButton').click(function () {
        return ValidateEmployee();
    });
});

function ValidateEmployee() {
    var returnValue = true;
    var nonDateValid = true;

    //notes:    validate last name
    if ($('.ValidateLastName').val().trim().length <= 0) {
        $('#ValidationMessageLastName').show();
        returnValue = false;
        nonDateValid = false;

        $('.ValidateLastName').focus();
    } else {
        $('#ValidationMessageLastName').hide();
    }

    //notes:    validate first name
    if ($('.ValidateFirstName').val().trim().length <= 0) {
        $('#ValidationMessageFirstName').show();
        returnValue = false;
        nonDateValid = false;

        $('.ValidateFirstName').focus();
    } else {
        $('#ValidationMessageLastName').hide();
    }

    //notes:    iterate through all the date validate fields
    var dateFieldObject;

    $('.ValidateDate').each(function (index) {
        if ($(this).val().trim().length > 0) {
            //notes:    has value - check for valid date
            if (IsDate($(this).val())) {
                //alert('here');
                $('#' + $(this).data('validationMessageId')).hide();
            } else {
                $('#' + $(this).data('validationMessageId')).show();
                //notes:    set focus to first date field  only if requried
                //          fields validation failed
                if (nonDateValid) {
                    if (dateFieldObject === undefined) {
                        dateFieldObject = $(this);
                        $(this).focus();
                    }
                }

                returnValue = false;
            }
        } else {
            $('#' + $(this).data('validationMessageId')).hide();
        }
    });

    return returnValue;
}

function IsDate(DateValue) {
    var currVal = DateValue;
    if (currVal == '')
        return false;

    var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/; //Declare Regex
    var dtArray = currVal.match(rxDatePattern); // is format OK?

    if (dtArray == null)
        return false;

    //Checks for mm/dd/yyyy format.
    dtMonth = dtArray[1];
    dtDay = dtArray[3];
    dtYear = dtArray[5];

    if (dtMonth < 1 || dtMonth > 12)
        return false;
    else if (dtDay < 1 || dtDay > 31)
        return false;
    else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31)
        return false;
    else if (dtMonth == 2) {
        var isLeap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
        if (dtDay > 29 || (dtDay == 29 && !isLeap))
            return false;
    }
    return true;
}