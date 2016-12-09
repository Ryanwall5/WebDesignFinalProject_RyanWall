var rh = rh || {};

rh.list = rh.list || {};

rh.list.editing = false;

//rh.list.attacheventhandler = function () {
//    console.log("called attacheventhandler");
//    //shown.bs.modal is a event that gets called when you open the modal
//    $("#insert-List-Item-Modal").on('shown.bs.modal', function () {
//        console.log("called shown.bs.modal");
//        $("input[name=NameOfDuty]").focus();
//    });
//        $("#edit-Item-Modal").on('shown.bs.modal', function () {
//            console.log("called shown.bs.modal");
//            $("input[name=NameOfDuty]").focus();
//    });
//};


rh.list.enablebuttons = function () {
    console.log("called EnableButtons");
    $("#toggle-edit").click(function () {
        if (rh.list.editing) {
            console.log("insidebuttonclick");
            rh.list.editing = false;

            $(".edit-actions").addClass("hidden");
            $(this).html("Edit");
           
        } else {
            rh.list.editing = true;
            $(".edit-actions").removeClass("hidden");
            $(this).html("Done");
        }
    });
};

    //$("#add-list-item").click(function () {

    //    //$("#insert-List-Item-Modal .modal-title").html("Add a List Item");
    //    //$("#insert-List-Item-Modal button[type=submit]").html("Add Item");

    //    // $("#insert-List-Item-Modal input[name=NameOfDuty]").val("");
    //    // $("#insert-List-Item-Modal input[name=Date]").val("");
    //    // $("#insert-List-Item-Modal input[name=DateToFinish]").val("");
    //    $("#IsChecked-Input").click(function () { 
    //        console.log("clicked on checkbox");
    //        //$("#edit-Item-Modal input[name=IsChecked]").val(Boolean(check));
    //        addcheck = this.checked;
           
    //        if (addcheck == true) {

    //            console.log("inside true");
    //        }
    //        else {

    //            console.log("inside false");
    //        }

    //        $("#insert-List-Item-Modal input[name=IsChecked").val(Boolean(addcheck));

    //    });
      
    //    // $("#insert-List-Item-Modal input[name=ToDoListId]").val("").prop("disabled", true);
       
    //});

   
    //$(".edit-list-item").click(function () {
    //    //$("#insert-List-Item-Modal .modal-title").html("Edit This List Item");
    //    //$("#insert-List-Item-Modal button[type=submit]").html("Edit List");
    //    console.log("inside editlistitem")

    //    id = $(this).find(".id").html();
        
    //    name = $(this).find(".name").html();
       
    //    date = $(this).find(".date").html();
       
    //    dateto = $(this).find(".datetofinish").html();
        
    //     check = $(this).find(".ischecked").html();
        
    //    if (check == true ) {
      
             
    //        console.log("inside true");
    //    }
    //    else {
      
    //        console.log("inside false");
    //    }
      
        
    //    console.log("id = " + id);
    //    console.log("name = " + name);
    //    console.log("date = " + date);
    //    console.log("dateto = " + dateto);
    //    $("#edit-Item-Modal input[name=ToDoListId]").val(id);
    //    $("#edit-Item-Modal input[name=NameOfDuty]").val(name);
    //    $("#edit-Item-Modal input[name=Date]").val(date);
    //    $("#edit-Item-Modal input[name=DateToFinish]").val(dateto);
    //    $("#edit-Item-Modal input[name=IsChecked]").val(Boolean(check));

    //    //$("#insert-List-Item-Modal input[name=ToDoListId]").val(id).prop("disabled", false);



    //    //$("#formid").attr("action", "ToDoList/Edit");
       

//    });
//};



$(document).ready(function () {

    //rh.list.attacheventhandler();
    rh.list.enablebuttons();
});



//console.log("hello, world");
//$("#toggle-edit").click(function () {

//    $(".edit-actions").toggleClass("hidden");

//});