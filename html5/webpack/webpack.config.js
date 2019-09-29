const path = require('path')

let config = {
    mode: 'none',
    entry: {
        main: path.join(__dirname, './src/main.js')
    },
    output: {
        filename: '[name].bundle.js',
        path: path.join(__dirname, './dist'),
        publicPath: 'dist/'
    },
    module: {
        rules: [
            {
                test: /\.(js)$/,
                exclude: /(node_modules|bower_components)/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: ['@babel/preset-env'],
                        plugins: ['@babel/transform-runtime']
                    }
                }
            },
            {
                test: /\.(png|jpe?g|gif|svg|dat)$/,
                loader: 'url-loader',
                query: {
                    limit: 1024000, // bytes
                    name: 'images/[name].[hash].[ext]'
                }
            }
        ],
    }
}

module.exports = config