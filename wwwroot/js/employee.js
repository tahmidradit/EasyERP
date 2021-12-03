$(document).ready(function(){

    var firstName = $('#firstName').val();
    var lastName = $('#lastName').val();
    var department = $('#department').val();
    var country = $('#country').val();

    $('#employeeCreateSubmit').click(function(){

    

        if($('#firstName').val() == "" || $('#lastName').val() == "" || $('#department').val() == "" || $('#semester').val() == "") {
            alert("You can't leave any fields empty !");
        }

        else {
            
            $.ajax({
                type: 'POST',
                data: $('#employeeCreateForm').serialize(),
                success: function (response) {
                    alert("SUCCESS");
                },
                error: function (response) {
                    alert("ERROR");
                }
            });
        }
        
    });

    $('#employeeEditSubmit').click(function(){

        if(firstName != "" && lastName != "" && department != "" && country != "") {

            $.ajax({
                type: 'POST',
                data: $('#employeeEditForm').serialize(),
                success: function (response) {
                    alert("SUCCESS");
                },
                error: function (response) {
                    alert("ERROR");
                }
            });
        }

        else {
            alert("You can't leave any fields empty !");
        }
        
    });

    $('#employeeDeleteSubmit').click(function(){
        
        if(firstName != "" && lastName != "" && department != "" && country != "") {

            $.ajax({
                type: 'POST',
                data: $('#employeeDeleteForm').serialize(),
                success: function (response) {
                    alert("SUCCESS");
                },
                error: function (response) {
                    alert("ERROR");
                }
            });
        }

        else {
            alert("You can't leave any fields empty !");
        }
        
    });

});