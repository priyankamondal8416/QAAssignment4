//validate data on form before allowing it to be sent on
var validYear = false;
var validnumber = false;
var validemail = false;
var validvalue = false;

function validate() {

    var seller = document.getElementById('sellerText');
    var address = document.getElementById('addressText');
    var city = document.getElementById('cityText');
    var phoneNumber = document.getElementById('phnoText');
    var email = document.getElementById('emailText');
    var make = document.getElementById('makeText');
    var model = document.getElementById('modelText');
    var year = document.getElementById('yearText');
    var valid = true;

    if (!seller.value || !validValue) {
        errorSellerName.innerText = "Please enter seller name.";
        errorSellerName.style.color = "red";
        valid = false;
    }
    if (!address.value || address.value.length < 2) {
        erroraddress.innerText = "Please enter address.";
        erroraddress.style.color = "red";
        valid = false;
    }
    if (!city.value || city.value.length < 2) {
        errorcity.innerText = "Please enter city.";
        errorcity.style.color = "red";
        valid = false;
    }
    if (!phoneNumber.value || !validnumber) {
        errorphoneNumber.innerText = "Please enter phone number. Check the 'info' to see suported format";
        errorphoneNumber.style.color = "red";
        valid = false;
    }
    if (!email.value || !validemail) {
        erroremail.innerText = "Please enter email.";
        erroremail.style.color = "red";
        valid = false;
    }
    if (!make.value || make.value.length < 1) {
        errormake.innerText = "Please enter vehichel make.";
        errormake.style.color = "red";
        valid = false;
    }
    if (!model.value || model.value.length < 2) {
        errormodel.innerText = "Please enter vehichel model.";
        errormodel.style.color = "red";
        valid = false;
    }
    if (!year.value || !validYear) {
        errormsg.innerText = "Please enter year.";
        errormsg.style.color = "red";
        valid = false;
    }

    // if valid then contact serve to insert the data
    if (valid) {

        let SellerName = seller.value;
        let Address = address.value;
        let City = city.value;
        let PHNo = phoneNumber.value;
        let Email = email.value;
        let VehichleMake = make.value.split(' ').join('-');
        let VehichleModel = model.value.split(' ').join('-');
        let VehichleYear = year.value.split(' ').join('-');

        let val = SellerName + ',' + Address + ',' + City + ',' + PHNo + ',' + Email + ',' + VehichleMake + ',' + VehichleModel + ',' + VehichleYear;
        let data = { SellerName: SellerName, Address: Address, City: City, PHNo: PHNo, Email: Email, VehichleMake: VehichleMake, VehichleModel: VehichleModel, VehichleYear: VehichleYear };
        let itemsArray = localStorage.getItem('items') ? JSON.parse(localStorage.getItem('items')) : [];

        localStorage.setItem('items', JSON.stringify(itemsArray));
        const data1 = JSON.parse(localStorage.getItem('items'));
        itemsArray.push(data);
        localStorage.setItem('items', JSON.stringify(itemsArray));
        let link = `https://www.jdpower.com/Cars/` + VehichleMake + `/` + VehichleModel + `/` + VehichleYear;
        
    }
}


function loadSavedData() {

    let values = JSON.parse(localStorage.getItem('items'));
    var details = '';
    var card = document.getElementById('card');
    if (values.length > 0) {
        if (card) {
            let index = values.length-1
            let sellerName = values[index].SellerName + ` (Contact: ` + values[index].PHNo + ` OR Email: ` + values[index].Email + `)`;
            let address = values[index].Address + `, ` + values[index].City;
            let vehichleDetail = values[index].VehichleMake + ` ` + values[index].VehichleModel + ` ` + values[index].VehichleYear;
            let link = `https://www.jdpower.com/Cars/` + values[index].VehichleMake + `/` + values[index].VehichleModel + `/` + values[index].VehichleYear;

            details += `<div class="card" style="margin: 10px;"> <div class="card-body"> <h5 class="card-title">` + vehichleDetail + `</h5> <h6 class="card-subtitle mb-2 text-muted">` + address + `</h6> <p class="card-text">` + sellerName + `</p> <a href="` + link + `" class="btn btn-info">` + link + `</a> </div> </div>`;
        }
        console.log(details);
        card.innerHTML = details;
    }
    else if (card) {
        card.innerHTML = `<h4 class="card-title productTitle" id="productTitle"> Opps! Something went wrong. Please try again.</h4>`;
    }

}


function loadData() {

    let values = JSON.parse(localStorage.getItem('items'));
    var details = '';
    var card = document.getElementById('card');
    if (values && values.length > 0) {
        if (card) {
            for (let index = values.length - 1; index >= 0; index--) {

                let sellerName = values[index].SellerName + ` (Contact: ` + values[index].PHNo + ` OR Email: ` + values[index].Email + `)`;
                let address = values[index].Address + `, ` + values[index].City;
                let vehichleDetail = values[index].VehichleMake + ` ` + values[index].VehichleModel + ` ` + values[index].VehichleYear;
                let link = `https://www.jdpower.com/Cars/` + values[index].VehichleMake + `/` + values[index].VehichleModel + `/` + values[index].VehichleYear;

                details += `<div class="card" style="margin: 10px;"> <div class="card-body"> <h5 class="card-title">` + vehichleDetail + `</h5> <h6 class="card-subtitle mb-2 text-muted">` + address + `</h6> <p class="card-text">` + sellerName + `</p> <a href="` + link + `" class="btn btn-info">` + link + `</a> </div> </div>`;
            }
            console.log(details);
            card.innerHTML = details;
        }
        else if (card) {
            card.innerHTML = `<h4 class="card-title productTitle" id="productTitle"> There are no Seller information availbale currently to display.</h4>`;
        }

    }

}

function yearValidation(year, ev) {

    var errormsg = document.getElementById('errormsg');
    var text = /^[0-9]+$/;
    errormsg.innerText = '';

    if (!year) {
        errormsg.innerText = "Enterd Year is not proper. Please check";
        errormsg.style.color = "red";
        validYear = false;
        return false;
    }

    if (ev.type == "blur" || year.length == 4 && ev.keyCode != 8 && ev.keyCode != 46) {
        if (year != 0) {
            if ((year != "") && (!text.test(year))) {

                errormsg.innerText = "Please Enter Numeric Values Only";
                errormsg.style.color = "red";
                validYear = false;
                return false;
            }

            if (year.length != 4) {
                errormsg.innerText = "Enterd Year is not proper. Please check";
                errormsg.style.color = "red";
                validYear = false;
                return false;

            }

            var current_year = new Date().getFullYear();
            if ((year < 2000) || (year > current_year)) {
                errormsg.innerText = "Year should be in range 2000 to current year";
                errormsg.style.color = "red";
                validYear = false;
                return false;
            }

            errormsg.innerText = '';
            validYear = true;
            return true;
        }
    }
}

function phoneNumberValidate(number) {

    var errormsg = document.getElementById('errorphoneNumber');
    var text = /^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$/;

    errormsg.innerText = '';

    if (number.length < 12) {
        errormsg.innerText = "Enterd number is not proper. Please check";
        errormsg.style.color = "red";
        validnumber = false;
        return false;
    }

    if ((number != "") && (!text.test(number))) {

        errormsg.innerText = "Please check the supported format";
        errormsg.style.color = "red";
        validnumber = false;
        return false;
    }

    errormsg.innerText = '';
    validnumber = true;
    return true;
}

function emailValidate(email) {

    var errormsg = document.getElementById('erroremail');
    var text = /^[\w]{1,}[\w.+-]{0,}@[\w-]{2,}([.][a-zA-Z]{2,}|[.][\w-]{2,}[.][a-zA-Z]{2,})$/;

    errormsg.innerText = '';

    if (!email) {
        errormsg.innerText = "Please enter proper email address. (ex. test@gmail.com, test@gb.co.in)";
        errormsg.style.color = "red";
        validemail = false;
        return false;
    }

    if ((email != "") && (!text.test(email))) {

        errormsg.innerText = "Please enter proper email address. (ex. test@gmail.com, test@gb.co.in)";
        errormsg.style.color = "red";
        validemail = false;
        return false;
    }

    errormsg.innerText = '';
    validemail = true;
    return true;
}

function validValue(value, errorSpanId) {

    errorSpanId.innerText = '';

    if (!value || value.length < 2) {
        errorSpanId.innerText = "Please enter value. Minimum 2 characters are require.";
        errorSpanId.style.color = "red";
        validvalue = false;
        return false;
    }

    errorSpanId.innerText = '';
    validvalue = true;
    return true;
}


function findCars() {

    let values = JSON.parse(localStorage.getItem('items'));
    var searchText = document.getElementById('searchText');
    var details = "";
    var result = [];
    var searchList = document.getElementById('searchList');

    if (values && values.length > 0) {

        if (searchText.value && searchText.value.length > 0) {

            for (let index = values.length - 1; index >= 0; index--) {
                if (values.find(name => values[index].SellerName.toLowerCase().trim() === searchText.value.toLowerCase().trim() || values[index].VehichleMake.toLowerCase().trim() == searchText.value.toLowerCase().trim() || values[index].VehichleModel.toLowerCase().trim() == searchText.value.toLowerCase().trim() || values[index].VehichleYear.toLowerCase().trim() == searchText.value.toLowerCase().trim()))
                    result.push(values[index]);
            }

            if (searchList && result.length > 0) {
                for (let index = result.length - 1; index >= 0; index--) {

                    let sellerName = result[index].SellerName + ` (Contact: ` + result[index].PHNo + ` OR Email: ` + result[index].Email + `)`;
                    let address = result[index].Address + `, ` + result[index].City;
                    let vehichleDetail = result[index].VehichleMake + ` ` + result[index].VehichleModel + ` ` + result[index].VehichleYear;
                    let link = `https://www.jdpower.com/Cars/` + result[index].VehichleMake + `/` + result[index].VehichleModel + `/` + result[index].VehichleYear;

                    details += `<div class="card" style="margin: 10px;"> <div class="card-body"> <h5 class="card-title">` + vehichleDetail + `</h5> <h6 class="card-subtitle mb-2 text-muted">` + address + `</h6> <p class="card-text">` + sellerName + `</p> <a href="` + link + `" class="btn btn-info">` + link + `</a> </div> </div>`;
                }
                searchList.innerHTML = details;
            }
            else {
                searchList.innerHTML = `<h5 class="card-title productTitle" id="productTitle"> No result found for '` + searchText.value + `' </h5>`;
            }
        }
        else {
            searchList.innerHTML = `<h5 class="card-title productTitle" id="productTitle"> Enter Vehicle Make OR Year OR Model OR Seller Name to search.</h5>`;
        }
    }
    else {
        searchList.innerHTML = `<h5 class="card-title productTitle" id="productTitle"> No Sellers found on website. Please add sellers.</h5>`;
    }
    searchText.value = "";
}

