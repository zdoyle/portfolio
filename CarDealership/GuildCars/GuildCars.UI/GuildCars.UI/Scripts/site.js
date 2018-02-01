$(document).ready(function () {

    PriceDropDownRules();
    YearDropDownRules();
    GetVehiclesViaSearch();
    GetSalesReportViaSearch();
    PopulateModelsDropdown();

});

function PriceDropDownRules() {

    //new vehicles dropdown rules
    $('#new-min-price-dropdown').change(function () {
        $('#new-max-price-dropdown option').each(function () {
            var thisOption = $(this);

            thisOption.prop('disabled', false);

            if (parseInt(thisOption.val()) <= parseInt($('#new-min-price-dropdown option:selected').val())) {
                thisOption.prop('disabled', true);
            }
        });
    });

    $('#new-max-price-dropdown').change(function () {
        $('#new-min-price-dropdown option').each(function () {
            var thisOption = $(this);

            thisOption.prop('disabled', false);

            if (parseInt(thisOption.val()) >= parseInt($('#new-max-price-dropdown option:selected').val())) {
                thisOption.prop('disabled', true);
            }
        });
    });

    //used vehicles dropdown rules
    $('#used-min-price-dropdown').change(function () {
        $('#used-max-price-dropdown option').each(function () {
            var thisOption = $(this);

            thisOption.prop('disabled', false);

            if (parseInt(thisOption.val()) <= parseInt($('#used-min-price-dropdown option:selected').val())) {
                thisOption.prop('disabled', true);
            }
        });
    });

    $('#used-max-price-dropdown').change(function () {
        $('#used-min-price-dropdown option').each(function () {
            var thisOption = $(this);

            thisOption.prop('disabled', false);

            if (parseInt(thisOption.val()) >= parseInt($('#used-max-price-dropdown option:selected').val())) {
                thisOption.prop('disabled', true);
            }
        });
    });

    //sales inventory vehicles dropdown rules
    $('#sales-inventory-min-price-dropdown').change(function () {
        $('#sales-inventory-max-price-dropdown option').each(function () {
            var thisOption = $(this);

            thisOption.prop('disabled', false);

            if (parseInt(thisOption.val()) <= parseInt($('#sales-inventory-min-price-dropdown option:selected').val())) {
                thisOption.prop('disabled', true);
            }
        });
    });

    $('#sales-inventory-max-price-dropdown').change(function () {
        $('#sales-inventory-min-price-dropdown option').each(function () {
            var thisOption = $(this);

            thisOption.prop('disabled', false);

            if (parseInt(thisOption.val()) >= parseInt($('#sales-inventory-max-price-dropdown option:selected').val())) {
                thisOption.prop('disabled', true);
            }
        });
    });

    //admin inventory vehicles dropdown rules
    $('#admin-inventory-min-price-dropdown').change(function () {
        $('#admin-inventory-max-price-dropdown option').each(function () {
            var thisOption = $(this);

            thisOption.prop('disabled', false);

            if (parseInt(thisOption.val()) <= parseInt($('#admin-inventory-min-price-dropdown option:selected').val())) {
                thisOption.prop('disabled', true);
            }
        });
    });

    $('#admin-inventory-max-price-dropdown').change(function () {
        $('#admin-inventory-min-price-dropdown option').each(function () {
            var thisOption = $(this);

            thisOption.prop('disabled', false);

            if (parseInt(thisOption.val()) >= parseInt($('#admin-inventory-max-price-dropdown option:selected').val())) {
                thisOption.prop('disabled', true);
            }
        });
    });
}

function YearDropDownRules() {

    //new vehicles dropdown rules
    $('#new-min-year-dropdown').change(function () {
        $('#new-max-year-dropdown option').each(function () {
            var thisOption = $(this);

            thisOption.prop('disabled', false);

            if (parseInt(thisOption.val()) <= parseInt($('#new-min-year-dropdown option:selected').val())) {
                thisOption.prop('disabled', true);
            }
        });
    });

    $('#new-max-year-dropdown').change(function () {
        $('#new-min-year-dropdown option').each(function () {
            var thisOption = $(this);

            thisOption.prop('disabled', false);

            if (parseInt(thisOption.val()) >= parseInt($('#new-max-year-dropdown option:selected').val())) {
                thisOption.prop('disabled', true);
            }
        });
    });

    //used vehicles dropdown rules
    $('#used-min-year-dropdown').change(function () {
        $('#used-max-year-dropdown option').each(function () {
            var thisOption = $(this);

            thisOption.prop('disabled', false);

            if (parseInt(thisOption.val()) <= parseInt($('#used-min-year-dropdown option:selected').val())) {
                thisOption.prop('disabled', true);
            }
        });
    });

    $('#used-max-year-dropdown').change(function () {
        $('#used-min-year-dropdown option').each(function () {
            var thisOption = $(this);

            thisOption.prop('disabled', false);

            if (parseInt(thisOption.val()) >= parseInt($('#used-max-year-dropdown option:selected').val())) {
                thisOption.prop('disabled', true);
            }
        });
    });

    //sales inventory dropdown rules
    $('#sales-inventory-min-year-dropdown').change(function () {
        $('#sales-inventory-max-year-dropdown option').each(function () {
            var thisOption = $(this);

            thisOption.prop('disabled', false);

            if (parseInt(thisOption.val()) <= parseInt($('#sales-inventory-min-year-dropdown option:selected').val())) {
                thisOption.prop('disabled', true);
            }
        });
    });

    $('#sales-inventory-max-year-dropdown').change(function () {
        $('#sales-inventory-min-year-dropdown option').each(function () {
            var thisOption = $(this);

            thisOption.prop('disabled', false);

            if (parseInt(thisOption.val()) >= parseInt($('#sales-inventory-max-year-dropdown option:selected').val())) {
                thisOption.prop('disabled', true);
            }
        });
    });

    //admin inventory dropdown rules
    $('#admin-inventory-min-year-dropdown').change(function () {
        $('#admin-inventory-max-year-dropdown option').each(function () {
            var thisOption = $(this);

            thisOption.prop('disabled', false);

            if (parseInt(thisOption.val()) <= parseInt($('#admin-inventory-min-year-dropdown option:selected').val())) {
                thisOption.prop('disabled', true);
            }
        });
    });

    $('#admin-inventory-max-year-dropdown').change(function () {
        $('#admin-inventory-min-year-dropdown option').each(function () {
            var thisOption = $(this);

            thisOption.prop('disabled', false);

            if (parseInt(thisOption.val()) >= parseInt($('#admin-inventory-max-year-dropdown option:selected').val())) {
                thisOption.prop('disabled', true);
            }
        });
    });
}

function GetVehiclesViaSearch() {

    $('#new-reset-button').click(function () {
        ResetNewSearchBox();
    });

    $('#used-reset-button').click(function () {
        ResetUsedSearchBox();
    });

    $('#sales-inventory-reset-button').click(function () {
        ResetSalesInventorySearchBox();
    });

    $('#admin-inventory-reset-button').click(function () {
        ResetAdminInventorySearchBox();
    });

    $('#new-search-button').click(function () {

        var searchQuery = $('#new-quick-search-box').val();
        var minPrice = $('#new-min-price-dropdown').val();
        var maxPrice = $('#new-max-price-dropdown').val();
        var minYear = $('#new-min-year-dropdown').val();
        var maxYear = $('#new-max-year-dropdown').val();

        if (!searchQuery) {
            searchQuery = 'No Search';
        }

        var constructedUrl = 'http://localhost:62045/inventory/vehicles/new/get/' + searchQuery + '/' + minPrice + '/' + maxPrice + '/' + minYear + '/' + maxYear

        $('#new-search-form select>option:selected').each(function () {
            $(this).prop('selected', false);
        });

        $('#new-search-form select>option:first').prop('selected', true);

        $('#new-search-form select>option:disabled').each(function () {
            $(this).prop('disabled', false);
        });

        $('#new-search-data-container-all').empty();

        $.ajax({
            type: 'GET',
            url: constructedUrl,
            success: function (data, status) {

                $('.results-header').empty();

                if (data.length === 1) {
                    $('.results-header').append('Search Results <small>(' + data.length + ' vehicle)</small>');
                }

                else {
                    $('.results-header').append('Search Results <small>(' + data.length + ' vehicles)</small>');
                }

                if (data.length === 0) {

                    $('#new-search-data-container-all').append('p').text('Your search query resulted in 0 vehicles found.  Please broaden your search parameters.');

                }

                else {

                    $.each(data, function (index, vehicle) {

                        var newHtml = BuildVehcileDetails(vehicle);

                        $('#new-search-data-container-all').append(newHtml);

                    });

                }

            },
            error: function () {
                
                $('#new-search-data-container-all').append('p').text('Error resetting search box.  Please refresh page.');

                $('#new-search-data-container-all>p').addClass('bg-danger');

            }
        });
    });

    $('#used-search-button').click(function () {

        var searchQuery = $('#used-quick-search-box').val();
        var minPrice = $('#used-min-price-dropdown').val();
        var maxPrice = $('#used-max-price-dropdown').val();
        var minYear = $('#used-min-year-dropdown').val();
        var maxYear = $('#used-max-year-dropdown').val();

        if (!searchQuery) {
            searchQuery = 'No Search';
        }

        var constructedUrl = 'http://localhost:62045/inventory/vehicles/used/get/' + searchQuery + '/' + minPrice + '/' + maxPrice + '/' + minYear + '/' + maxYear

        $('#used-search-form select>option:selected').each(function () {
            $(this).prop('selected', false);
        });

        $('#used-search-form select>option:first').prop('selected', true);

        $('#used-search-form select>option:disabled').each(function () {
            $(this).prop('disabled', false);
        });

        $('#used-search-data-container-all').empty();

        $.ajax({
            type: 'GET',
            url: constructedUrl,
            success: function (data, status) {

                $('.results-header').empty();

                if (data.length === 1) {
                    $('.results-header').append('Search Results <small>(' + data.length + ' vehicle)</small>');
                }

                else {
                    $('.results-header').append('Search Results <small>(' + data.length + ' vehicles)</small>');
                }
                
                if (data.length === 0) {

                    $('#used-search-data-container-all').append('p').text('Your search query resulted in 0 vehicles found.  Please broaden your search parameters.');

                }

                else {

                    $.each(data, function (index, vehicle) {

                        var newHtml = BuildVehcileDetails(vehicle);

                        $('#used-search-data-container-all').append(newHtml);

                    });

                }

            },
            error: function () {
                
                $('#used-search-data-container-all').append('p').text('Error resetting search box.  Please refresh page.');

                $('#used-search-data-container-all>p').addClass('bg-danger');

            }
        });
    });

    $('#sales-inventory-search-button').click(function () {

        var searchQuery = $('#sales-inventory-quick-search-box').val();
        var minPrice = $('#sales-inventory-min-price-dropdown').val();
        var maxPrice = $('#sales-inventory-max-price-dropdown').val();
        var minYear = $('#sales-inventory-min-year-dropdown').val();
        var maxYear = $('#sales-inventory-max-year-dropdown').val();

        if (!searchQuery) {
            searchQuery = 'No Search';
        }

        var constructedUrl = 'http://localhost:62045/inventory/vehicles/all/get/' + searchQuery + '/' + minPrice + '/' + maxPrice + '/' + minYear + '/' + maxYear

        $('#sales-inventory-search-form select>option:selected').each(function () {
            $(this).prop('selected', false);
        });

        $('#sales-inventory-search-form select>option:first').prop('selected', true);

        $('#sales-inventory-search-form select>option:disabled').each(function () {
            $(this).prop('disabled', false);
        });

        $('#sales-inventory-search-data-container-all').empty();

        $.ajax({
            type: 'GET',
            url: constructedUrl,
            success: function (data, status) {

                $('.results-header').empty();

                if (data.length === 1) {
                    $('.results-header').append('Search Results <small>(' + data.length + ' vehicle)</small>');
                }

                else {
                    $('.results-header').append('Search Results <small>(' + data.length + ' vehicles)</small>');
                }

                if (data.length === 0) {

                    $('#sales-inventory-search-data-container-all').append('p').text('Your search query resulted in 0 vehicles found.  Please broaden your search parameters.');

                }

                else {

                    $.each(data, function (index, vehicle) {

                        var newHtml = BuildVehcileDetails(vehicle);

                        $('#sales-inventory-search-data-container-all').append(newHtml);

                    });

                }

            },
            error: function () {

                $('#sales-inventory-search-data-container-all').append('p').text('Error resetting search box.  Please refresh page.');

                $('#sales-inventory-search-data-container-all>p').addClass('bg-danger');

            }
        });
    });

    $('#admin-inventory-search-button').click(function () {

        var searchQuery = $('#admin-inventory-quick-search-box').val();
        var minPrice = $('#admin-inventory-min-price-dropdown').val();
        var maxPrice = $('#admin-inventory-max-price-dropdown').val();
        var minYear = $('#admin-inventory-min-year-dropdown').val();
        var maxYear = $('#admin-inventory-max-year-dropdown').val();

        if (!searchQuery) {
            searchQuery = 'No Search';
        }

        var constructedUrl = 'http://localhost:62045/inventory/vehicles/all/get/' + searchQuery + '/' + minPrice + '/' + maxPrice + '/' + minYear + '/' + maxYear

        $('#admin-inventory-search-form select>option:selected').each(function () {
            $(this).prop('selected', false);
        });

        $('#admin-inventory-search-form select>option:first').prop('selected', true);

        $('#admin-inventory-search-form select>option:disabled').each(function () {
            $(this).prop('disabled', false);
        });

        $('#admin-inventory-search-data-container-all').empty();

        $.ajax({
            type: 'GET',
            url: constructedUrl,
            success: function (data, status) {

                $('.results-header').empty();

                if (data.length === 1) {
                    $('.results-header').append('Search Results <small>(' + data.length + ' vehicle)</small>');
                }

                else {
                    $('.results-header').append('Search Results <small>(' + data.length + ' vehicles)</small>');
                }

                if (data.length === 0) {

                    $('#admin-inventory-search-data-container-all').append('p').text('Your search query resulted in 0 vehicles found.  Please broaden your search parameters.');

                }

                else {

                    $.each(data, function (index, vehicle) {

                        var newHtml = BuildVehcileDetails(vehicle);

                        $('#admin-inventory-search-data-container-all').append(newHtml);

                    });

                }

            },
            error: function () {

                $('#admin-inventory-search-data-container-all').append('p').text('Error resetting search box.  Please refresh page.');

                $('#admin-inventory-search-data-container-all>p').addClass('bg-danger');

            }
        });
    });

    function ResetNewSearchBox() {
        $('#new-search-form select>option:selected').each(function () {
            $(this).prop('selected', false);
        });

        $('#new-search-form select>option:first').prop('selected', true);

        $('#new-search-form select>option:disabled').each(function () {
            $(this).prop('disabled', false);
        });

        $('#new-search-data-container-all').empty();

        $('.results-header').empty();

        $('.results-header').append('Search Results');

        $.ajax({
            type: 'GET',
            url: 'http://localhost:62045/inventory/vehicles/new/get/No%20Search/0/150000/1900/3000',
            success: function (data, status) {

                if (data.length === 0) {

                    $('#new-search-data-container-all').append('p').text('Your search query resulted in 0 vehicles found.  Please broaden your search parameters.');

                }

                else {

                    $.each(data, function (index, vehicle) {

                        var newHtml = BuildVehcileDetails(vehicle);

                        $('#new-search-data-container-all').append(newHtml);

                    });

                }

            },
            error: function () {

                $('#new-search-data-container-all').append('p').text('Error resetting search box.  Please refresh page.');

                $('#new-search-data-container-all>p').addClass('bg-danger');

            }
        });
    }

    function ResetUsedSearchBox() {
        $('#used-search-form select>option:selected').each(function () {
            $(this).prop('selected', false);
        });

        $('#used-search-form select>option:first').prop('selected', true);

        $('#used-search-form select>option:disabled').each(function () {
            $(this).prop('disabled', false);
        });

        $('#used-search-data-container-all').empty();

        $('.results-header').empty();

        $('.results-header').append('Search Results');

        $.ajax({
            type: 'GET',
            url: 'http://localhost:62045/inventory/vehicles/used/get/No%20Search/0/150000/1900/3000',
            success: function (data, status) {
                

                if (data.length === 0) {

                    $('#used-search-data-container-all').append('p').text('Your search query resulted in 0 vehicles found.  Please broaden your search parameters.');

                }

                else {

                    $.each(data, function (index, vehicle) {

                        var newHtml = BuildVehcileDetails(vehicle);

                        $('#used-search-data-container-all').append(newHtml);

                    });

                }

            },
            error: function () {
                $('#used-search-data-container-all').append('p').text('Error resetting search box.  Please refresh page.');

                $('#new-search-data-container-all>p').addClass('bg-danger');
            }
        });
    }

    function ResetSalesInventorySearchBox() {
        $('#sales-inventory-search-form select>option:selected').each(function () {
            $(this).prop('selected', false);
        });

        $('#sales-inventory-search-form select>option:first').prop('selected', true);

        $('#sales-inventory-search-form select>option:disabled').each(function () {
            $(this).prop('disabled', false);
        });

        $('#sales-inventory-search-data-container-all').empty();

        $('.results-header').empty();

        $('.results-header').append('Search Results');

        $.ajax({
            type: 'GET',
            url: 'http://localhost:62045/inventory/vehicles/all/get/No%20Search/0/150000/1900/3000',
            success: function (data, status) {
                

                if (data.length === 0) {

                    $('#sales-inventory-search-data-container-all').append('p').text('Your search query resulted in 0 vehicles found.  Please broaden your search parameters.');

                }

                else {

                    $.each(data, function (index, vehicle) {

                        var newHtml = BuildVehcileDetails(vehicle);

                        $('#sales-inventory-search-data-container-all').append(newHtml);

                    });

                }

            },
            error: function () {
                $('#sales-inventory-search-data-container-all').append('p').text('Error resetting search box.  Please refresh page.');

                $('#new-search-data-container-all>p').addClass('bg-danger');
            }
        });
    }

    function ResetAdminInventorySearchBox() {
        $('#admin-inventory-search-form select>option:selected').each(function () {
            $(this).prop('selected', false);
        });

        $('#admin-inventory-search-form select>option:first').prop('selected', true);

        $('#admin-inventory-search-form select>option:disabled').each(function () {
            $(this).prop('disabled', false);
        });

        $('#admin-inventory-search-data-container-all').empty();

        $('.results-header').empty();

        $('.results-header').append('Search Results');

        $.ajax({
            type: 'GET',
            url: 'http://localhost:62045/inventory/vehicles/all/get/No%20Search/0/150000/1900/3000',
            success: function (data, status) {


                if (data.length === 0) {

                    $('#admin-inventory-search-data-container-all').append('p').text('Your search query resulted in 0 vehicles found.  Please broaden your search parameters.');

                }

                else {

                    $.each(data, function (index, vehicle) {

                        var newHtml = BuildVehcileDetails(vehicle);

                        $('#admin-inventory-search-data-container-all').append(newHtml);

                    });

                }

            },
            error: function () {
                $('#admin-inventory-search-data-container-all').append('p').text('Error resetting search box.  Please refresh page.');

                $('#new-search-data-container-all>p').addClass('bg-danger');
            }
        });
    }

    function BuildVehcileDetails(vehicle) {

        var newHtml = '<div class="details-list-group-items-container">';
        newHtml += '<div class="detailsListGroupItems">';
        newHtml += '<div class="col-xs-12">';
        newHtml += '<h2 class="text-left">' + vehicle.modelYear + ' ' + vehicle.make + ' ' + vehicle.model + '</h2>';
        newHtml += '</div>';
        newHtml += '<div class="col-lg-3 col-xs-12">';
        newHtml += '<div class="vehicleImages" style="background-image:url(/Images/' + vehicle.imageFileName + '); background-size: cover;"></div>';
        newHtml += '</div>';
        newHtml += '<div class="vehicle-details-table col-xs-12 col-lg-9">';
        newHtml += '<div class="col-xs-2 col-lg-2">';
        newHtml += '<div class="text-right">';
        newHtml += '<p><strong>Body Style:</strong></p>';
        newHtml += '</div>';
        newHtml += '</div>';
        newHtml += '<div class="col-xs-10 col-lg-2">';
        newHtml += '<div class="text-left">';
        newHtml += '<p>' + vehicle.bodyStyle + '</p>';
        newHtml += '</div>';
        newHtml += '</div>';
        newHtml += '<div class="col-xs-2 col-lg-2">';
        newHtml += '<div class="text-right">';
        newHtml += '<p><strong>Interior:</strong></p>';
        newHtml += '</div>';
        newHtml += '</div>';
        newHtml += '<div class="col-xs-10 col-lg-2">';
        newHtml += '<div class="text-left">';
        newHtml += '<p>' + vehicle.interiorColor + '<span class="colorBar" style="background-color:' + vehicle.interiorColorCode + ';">&nbsp</span></p>';
        newHtml += '</div>';
        newHtml += '</div>';
        newHtml += '<div class="col-xs-2 col-lg-2">';
        newHtml += '<div class="text-right">';
        newHtml += '<p><strong>Sale Price:</strong></p>';
        newHtml += '</div>';
        newHtml += '</div>';
        newHtml += '<div class="col-xs-10 col-lg-2">';
        newHtml += '<div class="text-left">';
        newHtml += '<p>$' + vehicle.salePrice + '</p>';
        newHtml += '</div>';
        newHtml += '</div>';
        newHtml += '<div class="col-xs-2 col-lg-2">';
        newHtml += '<div class="text-right">';
        newHtml += '<p><strong>Trans:</strong></p>';
        newHtml += '</div>';
        newHtml += '</div>';
        newHtml += '<div class="col-xs-10 col-lg-2">';
        newHtml += '<div class="text-left">';
        newHtml += '<p>' + vehicle.transmissionType + '</p>';
        newHtml += '</div>';
        newHtml += '</div>';
        newHtml += '<div class="col-xs-2 col-lg-2">';
        newHtml += '<div class="text-right">';
        newHtml += '<p><strong>Mileage:</strong></p>';
        newHtml += '</div>';
        newHtml += '</div>';
        newHtml += '<div class="col-xs-10 col-lg-2">';
        newHtml += '<div class="text-left">';

        if (parseInt(vehicle.mileage) < 1000) {

            newHtml += '<p>New</p>';

        }

        else {

            newHtml += '<p>' + vehicle.mileage + '</p>';

        }

        newHtml += '</div>';
        newHtml += '</div>';
        newHtml += '<div class="col-xs-2 col-lg-2">';
        newHtml += '<div class="text-right">';
        newHtml += '<p><strong>MSRP:</strong></p>';
        newHtml += '</div>';
        newHtml += '</div>';
        newHtml += '<div class="col-xs-10 col-lg-2">';
        newHtml += '<div class="text-left">';
        newHtml += '<p>$' + vehicle.msrp + '</p>';
        newHtml += '</div>';
        newHtml += '</div>';
        newHtml += '<div class="col-xs-2 col-lg-2">';
        newHtml += '<div class="text-right">';
        newHtml += '<p><strong>Color:</strong></p>';
        newHtml += '</div>';
        newHtml += '</div>';
        newHtml += '<div class="col-xs-10 col-lg-2">';
        newHtml += '<div class="text-left">';
        newHtml += '<p>' + vehicle.color + '<span class="colorBar" style="background-color:' + vehicle.colorCode + ';">&nbsp</span></p>';
        newHtml += '</div>';
        newHtml += '</div>';
        newHtml += '<div class="col-xs-2 col-lg-2">';
        newHtml += '<div class="text-right">';
        newHtml += '<p><strong>VIN #:</strong></p>';
        newHtml += '</div>';
        newHtml += '</div>';
        newHtml += '<div class="col-xs-10 col-lg-6">';
        newHtml += '<div class="text-left">';
        newHtml += '<p>' + vehicle.vin + '</p>';
        newHtml += '</div>';
        newHtml += '</div>';

        if ($('.page-header').text() == 'Sales') {
            newHtml += '<div class="col-xs-offset-8 col-xs-4">';
            newHtml += '<div class="col-xs-12">';
            newHtml += '<input type="button" id="vehicle-' + vehicle.vehicleId + '-purchase-button" class="btn btn-default col-xs-12 pull-right" value="Purchase" onclick="location.href=\'/Sales/Purchase/' + vehicle.vehicleId + '\'" />';
            newHtml += '</div>';
            newHtml += '</div>';
        }

        else if ($('.page-header').text() == 'Admin') {
            newHtml += '<div class="col-xs-offset-8 col-xs-4">';
            newHtml += '<div class="col-xs-12">';
            newHtml += '<input type="button" id="vehicle-' + vehicle.vehicleId + '-edit-button" class="btn btn-default col-xs-12 pull-right" value="Edit" onclick="location.href=\'/Admin/UpdateVehicle/' + vehicle.vehicleId + '\'" />';
            newHtml += '</div>';
            newHtml += '</div>';
        }

        else {
            newHtml += '<div class="col-xs-offset-8 col-xs-4">';
            newHtml += '<div class="col-xs-12">';
            newHtml += '<input type="button" id="vehicle-' + vehicle.vehicleId + '-details-button" class="btn btn-default col-xs-12 pull-right" value="Details" onclick="location.href=\'/Inventory/Details/' + vehicle.vehicleId + '\'" />';
            newHtml += '</div>';
            newHtml += '</div>';
        }

        newHtml += '</div>';
        newHtml += '</div>';
        newHtml += '</div>';

        return newHtml;

    }

    
}

function GetSalesReportViaSearch() {

    $('#sales-search-button').click(function () {

        var employeeName = $('#sales-employee-dropdown').val();
        var fromDate = $('#sales-from-date-box').val();
        var toDate = $('#sales-to-date-box').val();

        if (!employeeName) {
            employeeName = 'No Name';
        }


        if (!fromDate) {
            fromDate = '1900-01-01';
        }

        if (!toDate) {
            toDate = '3000-01-01';
        }

        var constructedUrl = 'http://localhost:62045/reports/get/all/' + employeeName + '/' + fromDate + '/' + toDate 

        $('#sales-employee-dropdown>option:selected').each(function () {
            $(this).prop('selected', false);
        });

        $('#sales-employee-dropdown>option:first').prop('selected', true);

        $("#sales-search-form input[type=date]").val("")

        $('#sales-report-table tbody').empty();

        $.ajax({
            type: 'GET',
            url: constructedUrl,
            success: function (data, status) {
                
                if (data.length === 0) {

                    $('#sales-report-table tbody').append('<tr><td colspan=3>Your search query yielded 0 results.  Please broaden your search parameters.</td></tr>');

                }

                else {

                    $.each(data, function (index, item) {
                        var newHtml = BuildSalesDetails(item);

                        $('#sales-report-table tbody').append(newHtml);

                    });

                }

            },
            error: function () {

                $('#sales-report-table tbody').append('<tr><td colspan=3>Fatal error.  Please refresh page.</td></tr>');

                $('#sales-report-table tbody *').addClass('bg-danger');

            }
        });


        function BuildSalesDetails(item) {
            var totalSalesToFixed = parseFloat(item.totalSales).toFixed(2)
            var totalSalesWithCommas = addCommas(totalSalesToFixed);

            var newHtml = '<tr>';
            newHtml += '<td>' + item.employeeName + '</td>';
            newHtml += '<td>$' + totalSalesWithCommas + '</td>';
            newHtml += '<td>' + item.totalVehicles + '</td>';
            newHtml += '</tr>';

            return newHtml;
        }

        function addCommas (input) {
            // If the regex doesn't match, `replace` returns the string unmodified
            return (input.toString()).replace(
              // Each parentheses group (or 'capture') in this regex becomes an argument 
              // to the function; in this case, every argument after 'match'
              /^([-+]?)(0?)(\d+)(.?)(\d+)$/g, function (match, sign, zeros, before, decimal, after) {

                  // Less obtrusive than adding 'reverse' method on all strings
                  var reverseString = function (string) { return string.split('').reverse().join(''); };

                  // Insert commas every three characters from the right
                  var insertCommas = function (string) {

                      // Reverse, because it's easier to do things from the left
                      var reversed = reverseString(string);

                      // Add commas every three characters
                      var reversedWithCommas = reversed.match(/.{1,3}/g).join(',');

                      // Reverse again (back to normal)
                      return reverseString(reversedWithCommas);
                  };

                  // If there was no decimal, the last capture grabs the final digit, so
                  // we have to put it back together with the 'before' substring
                  return sign + (decimal ? insertCommas(before) + decimal + after : insertCommas(before + after));
              }
            );
        };
    });

}

function PopulateModelsDropdown() {

    $('#add-vehicle-make-dropdown').on('change', function() {
        
        $.ajax({
            
            type: 'GET',
            url: 'http://localhost:62045/inventory/vehicles/models/get/' + $('#add-vehicle-make-dropdown').val(),
            success: function (data, status) {

                $('#add-vehicle-model-dropdown').empty();

                $('#add-vehicle-model-dropdown').append('<option disabled selected>-Model-</option>')

                $.each(data, function (index, model) {

                    var newHtml = BuildModelOptions(model);

                    $('#add-vehicle-model-dropdown').append(newHtml);

                });

            },
            error: function () {

            }
        });

    });


    $('#update-vehicle-make-dropdown').on('change', function () {

        $.ajax({

            type: 'GET',
            url: 'http://localhost:62045/inventory/vehicles/models/get/' + $('#update-vehicle-make-dropdown').val(),
            success: function (data, status) {

                $('#update-vehicle-model-dropdown').empty();

                $('#update-vehicle-model-dropdown').append('<option disabled selected>-Model-</option>')

                $.each(data, function (index, model) {

                    var newHtml = BuildModelOptions(model);

                    $('#update-vehicle-model-dropdown').append(newHtml);

                });

            },
            error: function () {

            }
        });

        
    });

    function BuildModelOptions(model) {

        var newHtml = '<option value="' + model.model + '" >' + model.model + '</option>'

        return newHtml;
    }


}