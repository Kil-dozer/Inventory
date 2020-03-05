docker build -t sdg-my-famous-shop-image .

docker tag sdg-my-famous-shop-image registry.heroku.com/my-famous-shop/web

docker push registry.heroku.com/my-famous-shop/web

heroku container:release web -a my-famous-shop