//Event listener to close popups
$('.close-alert').click(() => {
    $('.alert').hide('fast');
});

let table = new DataTable('#contact-table');