(function($){
  $(function(){

      $('.button-collapse').sideNav();
      // Initialize collapsible (uncomment the line below if you use the dropdown variation)
      $('.collapsible').collapsible({
          accordion: true
      });
      $('.parallax').parallax();
      // Show sideNav
   

      $(document).ready(function () {
          $('select').material_select();
      });




      
    



  }); // end of document ready
})(jQuery); // end of jQuery name space