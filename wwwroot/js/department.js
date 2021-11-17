$(document).ready(function(){

    $('#departmentCreateSubmit').click(function(){
        
        if($('#Name').val() != "") { 
            $.ajax({
                type: 'POST',
                data: $('#departmentCreateForm').serialize(),
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



   

   

    
           



       