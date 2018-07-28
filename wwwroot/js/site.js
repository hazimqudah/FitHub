// Write your JavaScript code.

$(document).ready(function () {

        $("#jsFillButton").click(function () {
            $("#firstName").val("Hazim").prop('disabled', true);
            $("#lastName").val("Qudah").prop('disabled', true);
        });

    });

function NotImplemented() {
    alert('Feature not yet implemented.');
}

function logout() {
    location.href = "/Account/Logout";
}

function Home() {
    location.href = "/Home/Index";
}

function signIn() {
    location.href = "/Account/Login";
}

function register() {
    location.href = "/Account/Register"
}

var i = 1;
$("#add_row").click(function () {
    $('#addr' + i).html("<td>" + (i + 1) + "</td><td><input name='user" + i + "' type='date' placeholder='Date' class='form-control input-md'  /></td><td><input  name='pass" + i + "' type='text' placeholder='Name'  class='form-control input-md'></td><td><input  name='ip" + i + "' type='text' placeholder='Sets'  class='form-control input-md'></td><td><input  name='country" + i + "' type='text' placeholder='Reps'  class='form-control input-md'></td><td><input  name='ipDisp" + i + "' type='text' placeholder='Weight'  class='form-control input-md'></td>");

    $('#tab_logic').append('<tr id="addr' + (i + 1) + '"></tr>');
    i++;
});
$("#delete_row").click(function () {
    if (i > 1) {
        $("#addr" + (i - 1)).html('');
        i--;
    }
});
