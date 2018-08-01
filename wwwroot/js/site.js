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
$("#add_log_row").click(function () {
    $('#addr' + i).html("<div class='col-1'> <input type='text' class='form-control text-center' disabled='disabled' placeholder='" + i + "'/> </div> <div class='col-5'> <select class='form-control' id='ExName" + i + "' name='ExName" + i + "' placeholder='.col-4'></select> </div> <div class='col-2'> <input type='text' class='form-control' name='Sets" + i + "' placeholder='Sets'> </div> <div class='col-2'> <input type='text' class='form-control' name='Reps" + i + "' placeholder='Reps'> </div> <div class='col-2'> <input type='text' class='form-control' name='Weights" + i + "' placeholder='Weights'> </div>");
    $("<div class='form-row' id=" + "addr" + (i + 1) + "></div>").insertBefore("#submit");

    var $options = $("#HiddenExerciseList > select > option").clone();
    $('#ExName' + i).append($options);
    i++;
});

$("#delete_log_row").click(function () {
    if (i > 1) {
        $("#addr" + (i - 1)).html('');
        i--;
    }
});
