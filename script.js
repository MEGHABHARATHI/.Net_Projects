$(document).ready(function() {
  $.ajax({
  url: "http://localhost:5104/api/Product",
  method: "GET",
  processData: false,
  contentType: false,
  data: null
}).done((response) => console.log(response));
$.ajax({
  url: "http://localhost:5104/api/subject",
  method: "GET",
  processData: false,
  contentType: false,
  data: null
}).done((response) => console.log(response));

});
 
 


// Inline click event function passed via HTML attribute
      

      $(document).ready(function() {
        console.log("Document is ready");
        const fruits = [
          { id:0, name: "Country Banana", img: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRpDzVKtuWW7gfwqlUfrSTVFeSV8v27B37zVz40-vNa0A&s=10",price: 80 },
          { id:1, name: "Mallika Mango", img: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQnP-Q-nwOkjrljj5cD1inQk9xHMCW_kM6GduaaThOPpw&s=10", price: 120 },
          { id:2,name: "Pomegranate", img: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSZmxy-moZPlJKdIfUL3KDXi9yKiwzXIGtLC_AnKQzGVQ&s=10",price: 150 },
          { id:3, name: "Guava", img: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSZmxy-moZPlJKdIfUL3KDXi9yKiwzXIGtLC_AnKQzGVQ&s=10", price: 60 }
      ];
 
       const container = document.getElementById('fruit-container');
 
       fruits.forEach(my_fav_fruit => {
          const div = document.createElement('div');
          div.className = 'fruit-item';

          //div.setAttribute('onclick', 'handleClick(this)');
 
          div.innerHTML = `<img src="${my_fav_fruit.img}" alt="${my_fav_fruit.name}"  width="250" height="150"> ${my_fav_fruit.name}<b>Rs.<div class='price'>${my_fav_fruit.price} </div>per kg</b> <button class="add-to-cart">Add to Cart</button>`;
          container.appendChild(div);
       });
        $('#disc_btn').button({disabled:true});

       var cart_items = [];
       $('#fruit-container').on('click', '.add-to-cart', 
        function() {
        console.log("Add to Cart button clicked...");
        let item =$(this).parent();
        cart_items.push(item);
        
        $(this).parent().toggleClass('active');
        $('#cart-badge').text(cart_items.length);

        });

        $('#disc_btn').click(() => {
          var disc_val= $('#disc_val').val();
          console.log(`Discount button clicked with value: ${disc_val}`);
          $('#disc_val').val('');

          $('.fruit-item.active').each((index, element) => {
            var text = $(element).text();
            var price=$(element).find('.price').text();
            console.log(`index: ${index}, element: ${element}`);

            var disc_price = price *(100-disc_val)/100;
            $(element).find('.price').text(disc_price);
            $(element).find('.price').hide().slideDown(800);
          });


        });

    });