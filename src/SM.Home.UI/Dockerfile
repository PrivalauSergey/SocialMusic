FROM node:18-alpine AS builder
WORKDIR /app

COPY src/SM.Home.UI/package*.json ./
RUN npm ci

COPY src/SM.Home.UI .

RUN npm run build -- -c production

FROM nginx:1.25-alpine
RUN rm -rf /usr/share/nginx/html/*

COPY --from=builder /app/dist/sm.home.ui/browser /usr/share/nginx/html/
COPY src/SM.Home.UI/nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 8080
CMD ["nginx", "-g", "daemon off;"]

