<?php
       if ((($_FILES["file"]["type"] == "image/png") && ($_FILES["file"]["size"] < 20000000000)) 
        { 
               if ($_FILES["file"]["error"] > 0)
               { 
                     echo "Return Code: " . $_FILES["file"]["error"] . ""; 
               } 
               else  
                     { 
                        
                         if (file_exists("upload/" . $_FILES["file"]["name"]))
                         {
                                 echo $_FILES["file"]["name"] . " already exists. ";
                         }
                          else
                          {
               			move_uploaded_file($_FILES["file"]["tmp_name"], "upload/" . $_FILES["file"]["name"]);
                               echo "Uploaded";
                          }
                     }
                }
          else 
          { 
             echo "Invalid file"; 
          } 
?>