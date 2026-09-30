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
 
          div.innerHTML = `<img src="${my_fav_fruit.img}" alt="${my_fav_fruit.name}"  width="250" height="150"> ${my_fav_fruit.name}<b>Rs.${my_fav_fruit.price}</b> <button class="add-to-cart">Add to Cart</button>`;
          container.appendChild(div);
       });

       $('#fruit-container').on('click', '.add-to-cart', function() {
        console.log("Add to Cart button clicked");
        $(this).parent().toggleClass('active');

      });
    });