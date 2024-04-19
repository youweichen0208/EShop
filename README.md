# Eshop Application

## Website Introduction:

Welcome to our E-commerce platform, where convenience meets commerce. Our Eshop website is dedicated to facilitating seamless transactions for both buyers and sellers. With our user-friendly interface, individuals can effortlessly post items for sale and browse through a diverse array of offerings. As customers, users can engage in secure transactions, leaving comments to provide feedback and enhance the community experience. Additionally, our platform enables users to manage their orders efficiently, access their purchase history, and conveniently set personalized shipping addresses. Join us in revolutionizing the online marketplace experience."

## Website functionalities:

### Home Page:

![Home Page](/assets/home.png)

This is the home page of my Eshop website.

### Signup Page:

![Signup Page](/assets/signup.png)
The signup page has validation rules. It will show errors if users don't enter correct format of input fields.

### Login Page:

![Login Page](/assets/login.png)
The login page will validate and authenticate the user information with the backend.

### Products Page:

![Products page](/assets/products.png)
This is the products page based on the category.

### Add comment:

![Comment page](/assets/comment.png)
This is the comment page where users can add comments about this product, which can give a better insights to the other users about this product.

### Product-Detail Page:

![Product Detail](/assets/reviews.png)
The reviews are generated right after users submit the reviews.

### Cart Page:

![Cart Page](/assets/cart.png)
This is the cart page for storing users' cart information.

### Order Detail:

![Order Detail](/assets/order-detail.png)
This is the order detail page that serves as a receipt for showing order id and order information.

### Order History:

![Order History](/assets/order-history.png)
Users can view their order and purchase history in the Order History page. When the user clicks on the `view details`, it will redirect to the order detail page of the specific order.

## Command to build amd64 on MacOS

```
docker buildx build --platform linux/amd64 -t eshopapplication.azurecr.io/reviews.api:latest -f ./ReviewsMicroservice/Reviews.API/Dockerfile .
```
